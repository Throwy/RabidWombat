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
                repetitions = (value == 0 ? 1 : value);
            }
        }

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
            return new Point((Convert.ToDouble(65535) * point.X) / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Width),
                (Convert.ToDouble(65535) * point.Y) / Convert.ToDouble(Screen.PrimaryScreen.Bounds.Height));
        }

        /// <summary>
        /// Plays the macro on the current thread.
        /// </summary>
        private void PlayMacro()
        {
            IsPlaying = true;

            for (int i = 0; i < Repetitions; i++)
            {
                foreach (MacroEvent current in CurrentMacro.Events)
                {
                    if (cancelled)
                    {
                        cancelled = false;
                        i = Repetitions;
                        break;
                    }

                    // delay event
                    if (current is MacroDelayEvent delayEvent)
                    {
                        Thread.Sleep(new TimeSpan(delayEvent.Delay));
                    }
                    // mouse move event
                    else if (current is MacroMouseMoveEvent mouseMoveEvent)
                    {
                        Point absolutePoint = ConvertPointToAbsolute(mouseMoveEvent.Location);
                        mouseSimulator.MoveMouseTo(absolutePoint.X, absolutePoint.Y);
                    }
                    // mouse down event
                    else if (current is MacroMouseDownEvent mouseDownEvent)
                    {
                        Point absolutePoint = ConvertPointToAbsolute(mouseDownEvent.Location);
                        mouseSimulator.MoveMouseTo(absolutePoint.X, absolutePoint.Y);
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
                        Point absolutePoint = ConvertPointToAbsolute(mouseUpEvent.Location);
                        mouseSimulator.MoveMouseTo(absolutePoint.X, absolutePoint.Y);
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
                        Point absolutePoint = ConvertPointToAbsolute(mouseWheelEvent.Location);
                        mouseSimulator.MoveMouseTo(absolutePoint.X, absolutePoint.Y);
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
