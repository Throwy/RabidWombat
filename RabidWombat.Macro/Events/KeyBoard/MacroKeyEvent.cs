namespace RabidWombat.Macro.Events.Keyboard
{
    /// <summary>
    /// Represents a keyboard event that happenes during recording.
    /// </summary>
    public abstract class MacroKeyEvent : MacroEvent
    {
        /// <summary>
        /// Gets or sets the virtual key code associated with the event.
        /// </summary>
        public int VirtualKeyCode { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro key event.
        /// </summary>
        /// <param name="virtualKeyCode"></param>
        protected MacroKeyEvent(int virtualKeyCode)
        {
            this.VirtualKeyCode = virtualKeyCode;
        }
    }
}
