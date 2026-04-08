namespace RabidWombat.Macro.Events.Keyboard
{
    /// <summary>
    /// Represents a key up event that happens during recording.
    /// </summary>
    public class MacroKeyUpEvent : MacroKeyEvent
    {
        /// <summary>
        /// Initializes a new instance of a macro key up event.
        /// </summary>
        /// <param name="virtualKeyCode">The virtual key code associated with the event.</param>
        public MacroKeyUpEvent(int virtualKeyCode) : base(virtualKeyCode)
        {
        }
    }
}
