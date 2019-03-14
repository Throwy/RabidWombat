using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabidWombat.Hooks.EventHandlers;
using RabidWombat.Hooks.Windows;
using RabidWombat.Macro.Events;
using RabidWombat.Macro.Events.Keyboard;
using RabidWombat.Macro.Events.Mouse;

namespace RabidWombat.Macro
{
    /// <summary>
    /// Allows recording sequences of mouse and keyboard events using global input hooks.
    /// </summary>
    public class MacroRecorder : IDisposable
    {
        /// <summary>
        /// Holds the mouse/keyboard hook.
        /// </summary>
        private HookManager hookManager;

        /// <summary>
        /// Holds the time in ticks that the last event occured.
        /// </summary>
        private long lastEventTime;

        /// <summary>
        /// Gets the macro currently being recorded.
        /// </summary>
        public Macro CurrentMacro { get; private set; }

        /// <summary>
        /// Gets the recorder's running state.
        /// </summary>
        public bool IsRecording { get; private set; }

        /// <summary>
        /// Initializes a new instance of a macro recorder.
        /// </summary>
        public MacroRecorder()
        {
            hookManager = new HookManager();

            hookManager.KeyDown += hook_KeyDown;
            hookManager.KeyUp += hook_KeyUp;
            hookManager.MouseDown += hook_MouseDown;
            hookManager.MouseUp += hook_MouseUp;
            hookManager.MouseMove += hook_MouseMove;
            hookManager.MouseWheel += hook_MouseWheel;
        }

        /// <summary>
        /// Releases all resources associated with this object.
        /// </summary>
        public void Dispose()
        {
            hookManager.Dispose();
        }

        /// <summary>
        /// Adds a delay event to the current macro representing the time in ticks since this method was last called.
        /// </summary>
        private void AddDelayEvent()
        {
            long timeNow = DateTime.Now.Ticks;
            CurrentMacro.AddEvent(new MacroDelayEvent(timeNow - lastEventTime));
            lastEventTime = timeNow;
        }

        /// <summary>
        /// Loads a macro into the macro recorder.
        /// </summary>
        /// <param name="macro"></param>
        public void LoadMacro(Macro macro)
        {
            CurrentMacro = macro;
        }

        /// <summary>
        /// Clears the current macro from the macro recorder.
        /// </summary>
        public void Clear()
        {
            CurrentMacro = new Macro();
        }

        /// <summary>
        /// Starts recording mouse and keyboard events.
        /// </summary>
        public void StartRecording()
        {
            if(CurrentMacro == null)
            {
                Clear();
            }
            lastEventTime = DateTime.Now.Ticks;
            IsRecording = true;
        }

        /// <summary>
        /// Stops recording mouse and keyboard events.
        /// </summary>
        public void StopRecording()
        {
            IsRecording = false;
        }

        private void hook_KeyDown(object sender, GlobalKeyEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroKeyDownEvent(e.VirtualKeyCode));
            }
        }

        private void hook_KeyUp(object sender, GlobalKeyEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroKeyUpEvent(e.VirtualKeyCode));
            }
        }

        private void hook_MouseDown(object sender, GlobalMouseEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroMouseDownEvent(e.Point, e.Button));
            }
        }

        private void hook_MouseUp(object sender, GlobalMouseEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroMouseUpEvent(e.Point, e.Button));
            }
        }

        private void hook_MouseMove(object sender, GlobalMouseEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroMouseMoveEvent(e.Point));
            }
        }

        private void hook_MouseWheel(object sender, GlobalMouseEventHandlerArgs e)
        {
            if(IsRecording)
            {
                AddDelayEvent();
                CurrentMacro.AddEvent(new MacroMouseWheelEvent(e.Point, e.Delta));
            }
        }
    }
}
