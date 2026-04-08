namespace RabidWombat.Macro.Events.Keyboard
{
    /// <summary>
    /// Represents a key down event that happens during recording.
    /// </summary>
    public class MacroKeyDownEvent : MacroKeyEvent
    {
        /// <summary>
        /// Initializes a new instance of a macro key down event.
        /// </summary>
        /// <param name="virtualKeyCode">The virtual key code associated with the event.</param>
        public MacroKeyDownEvent(int virtualKeyCode) : base(virtualKeyCode)
        {
        }
    }
}
