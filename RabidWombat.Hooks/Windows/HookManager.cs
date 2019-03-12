using RabidWombat.Hooks.EventHandlers;
using System;

namespace RabidWombat.Hooks.Windows
{
    /// <summary>
    /// Provides events and methods for easily managing global input events.
    /// </summary>
    public partial class HookManager : IDisposable
    {
        /// <summary>
        /// Raised whenever the global mouse hook detects a mouse move action.
        /// </summary>
        private event GlobalMouseEventHandler GlobalMouseMove;

        /// <summary>
        /// Raised whenever the global mouse hook detects a mouse down action.
        /// </summary>
        private event GlobalMouseEventHandler GlobalMouseDown;

        /// <summary>
        /// Raised whenever the global mouse hook detects a mouse up action.
        /// </summary>
        private event GlobalMouseEventHandler GlobalMouseUp;

        /// <summary>
        /// Raised whenever the global mouse hook detects a mouse wheel action.
        /// </summary>
        private event GlobalMouseEventHandler GlobalMouseWheel;

        /// <summary>
        /// Raised whenever the global keyboard hook detects a key up action.
        /// </summary>
        private event GlobalKeyEventHandler GlobalKeyUp;

        /// <summary>
        /// Raised whenever the global keyboard hook detects a key down action.
        /// </summary>
        private event GlobalKeyEventHandler GlobalKeyDown;



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
