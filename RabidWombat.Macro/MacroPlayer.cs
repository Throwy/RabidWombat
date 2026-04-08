using RabidWombat.Macro.Events;
using RabidWombat.Macro.Events.Keyboard;
using RabidWombat.Macro.Events.Mouse;
using RabidWombat.Simulation;
using RabidWombat.Simulation.Keyboard;
using RabidWombat.Simulation.Mouse;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace RabidWombat.Macro
{
    /// <summary>
    /// Provides support for playing recorded macros.
    /// </summary>
    public class MacroPlayer
    {
        /// <summary>
        /// Holds the mouse simulator.
        /// </summary>
        private MouseSimulator mouseSimulator;

        /// <summary>
        /// Holds the keyboard simulator.
        /// </summary>
        private KeyboardSimulator keyboardSimulator;

        /// <summary>
        /// Holds the thread that the macro is currently executing on.
        /// </summary>
        private Thread macroThread;

        /// <summary>
        /// Holds the execution cancel state.
        /// </summary>
        private bool cancelled;

        /// <summary>
        /// Random number generator used for human-like jitter.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Holds the last jittered click location so mouse up lands at the same spot as mouse down.
        /// </summary>
        private Point? _lastClickTarget;

        /// <summary>
        /// Holds the number of times the macro should repeat before ending.
        /// </summary>
        private int repetitions;

        /// <summary>
        /// Gets the macro currently loaded into the player.
        /// </summary>
        public Macro CurrentMacro { get; private set; }

        /// <summary>
        /// Gets or sets the number of times the macro should repeat before ending.
        /// </summary>
        public int Repetitions
        {
            get
            {
                return repetitions;
            }
            set
            {
                repetitions = value == 0 ? 1 : value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum random delay added to each timing event in milliseconds (0 = disabled).
        /// </summary>
        public int DelayJitter { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum random pixel offset applied to each mouse position (0 = disabled).
        /// </summary>
        public int MouseJitter { get; set; } = 0;

        /// <summary>
        /// Gets whether or not a macro is being played.
        /// </summary>
        public bool IsPlaying { get; private set; }

        /// <summary>
        /// Initializes a new instance of a macro player.
        /// </summary>
        public MacroPlayer()
        {
            mouseSimulator = new MouseSimulator(new InputSimulator());
            keyboardSimulator = new KeyboardSimulator(new InputSimulator());
            repetitions = 1;
            cancelled = false;
        }

        /// <summary>
        /// Cancels playbacl of the current macro.
        /// </summary>
        public void CancelPlayback()
        {
            cancelled = IsPlaying;
        }

        /// <summary>
        /// Loads a macro into the player.
        /// </summary>
        /// <param name="macro">The macro to load into the player.</param>
        public void LoadMacro(Macro macro)
        {
            CurrentMacro = macro;
        }

        /// <summary>
        /// Converts a point to absolute screen coordinates.
        /// </summary>
        /// <param name="point">The point to convert.</param>
        private Point ConvertPointToAbsolute(Point point)
        {
            return new Point(Convert.ToDouble(65535) * point.X / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width),
                Convert.ToDouble(65535) * point.Y / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height));
        }

        /// <summary>
        /// Applies random pixel offset to a point to simulate human imprecision.
        /// </summary>
        private Point ApplyMouseJitter(Point point)
        {
            if (MouseJitter == 0) return point;
            return new Point(
                point.X + _random.Next(-MouseJitter, MouseJitter + 1),
                point.Y + _random.Next(-MouseJitter, MouseJitter + 1));
        }

        /// <summary>
        /// Moves the mouse to an absolute target position over interpolated steps.
        /// Used for click/scroll events that may jump to a new position.
        /// </summary>
        private void MoveMouseSmooth(Point absoluteTarget)
        {
            double screenW = Screen.PrimaryScreen.Bounds.Width;
            double screenH = Screen.PrimaryScreen.Bounds.Height;
            Point from = new Point(
                65535.0 * Cursor.Position.X / screenW,
                65535.0 * Cursor.Position.Y / screenH);

            const int steps = 5;
            for (int step = 1; step <= steps; step++)
            {
                double t = (double)step / steps;
                mouseSimulator.MoveMouseTo(
                    from.X + (absoluteTarget.X - from.X) * t,
                    from.Y + (absoluteTarget.Y - from.Y) * t);
            }
        }

        /// <summary>
        /// Plays the macro on the current thread.
        /// </summary>
        private void PlayMacro()
        {
            IsPlaying = true;

            for (int i = 0; i < Repetitions; i++)
            {
                long referenceTicks = DateTime.Now.Ticks;
                long expectedElapsedTicks = 0;

                foreach (MacroEvent current in CurrentMacro.Events)
                {
                    if (cancelled)
                    {
                        cancelled = false;
                        i = Repetitions;
                        break;
                    }

                    // delay event — sleep only the time remaining after accounting for execution overhead
                    if (current is MacroDelayEvent delayEvent)
                    {
                        int jitterMs = DelayJitter > 0 ? _random.Next(0, DelayJitter + 1) : 0;
                        expectedElapsedTicks += delayEvent.Delay + TimeSpan.FromMilliseconds(jitterMs).Ticks;
                        long actualElapsedTicks = DateTime.Now.Ticks - referenceTicks;
                        long remainingTicks = expectedElapsedTicks - actualElapsedTicks;
                        if (remainingTicks > 0)
                            Thread.Sleep(new TimeSpan(remainingTicks));
                    }
                    // mouse move event — move directly since recorded points already form the path
                    else if (current is MacroMouseMoveEvent mouseMoveEvent)
                    {
                        Point abs = ConvertPointToAbsolute(mouseMoveEvent.Location);
                        mouseSimulator.MoveMouseTo(abs.X, abs.Y);
                    }
                    // mouse down event
                    else if (current is MacroMouseDownEvent mouseDownEvent)
                    {
                        _lastClickTarget = ConvertPointToAbsolute(ApplyMouseJitter(mouseDownEvent.Location));
                        MoveMouseSmooth(_lastClickTarget.Value);
                        if (mouseDownEvent.Button == System.Windows.Input.MouseButton.Left)
                        {
                            mouseSimulator.LeftButtonDown();
                        }
                        else if (mouseDownEvent.Button == System.Windows.Input.MouseButton.Right)
                        {
                            mouseSimulator.RightButtonDown();
                        }
                    }
                    // mouse up event
                    else if (current is MacroMouseUpEvent mouseUpEvent)
                    {
                        Point upTarget = _lastClickTarget ?? ConvertPointToAbsolute(mouseUpEvent.Location);
                        _lastClickTarget = null;
                        MoveMouseSmooth(upTarget);
                        if (mouseUpEvent.Button == System.Windows.Input.MouseButton.Left)
                        {
                            mouseSimulator.LeftButtonUp();
                        }
                        else if (mouseUpEvent.Button == System.Windows.Input.MouseButton.Right)
                        {
                            mouseSimulator.RightButtonUp();
                        }
                    }
                    // key down event
                    else if (current is MacroKeyDownEvent keyDownEvent)
                    {
                        keyboardSimulator.KeyDown((Simulation.Native.VirtualKeyCode)keyDownEvent.VirtualKeyCode);
                    }
                    // key up event
                    else if (current is MacroKeyUpEvent keyUpEvent)
                    {
                        keyboardSimulator.KeyUp((Simulation.Native.VirtualKeyCode)keyUpEvent.VirtualKeyCode);
                    }
                    // mouse wheel event
                    else if (current is MacroMouseWheelEvent mouseWheelEvent)
                    {
                        MoveMouseSmooth(ConvertPointToAbsolute(mouseWheelEvent.Location));
                        mouseSimulator.VerticalScroll(mouseWheelEvent.Delta / 120);
                    }
                }
            }

            IsPlaying = false;
        }

        /// <summary>
        /// Plays the macro on a separate background thread.
        /// </summary>
        public void PlayMacroAsync()
        {
            macroThread = new Thread(PlayMacro);
            macroThread.Start();
        }
    }
}
