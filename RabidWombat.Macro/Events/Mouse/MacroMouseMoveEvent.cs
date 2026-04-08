using System.Windows;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse move event that happens during recording.
    /// </summary>
    public class MacroMouseMoveEvent : MacroMouseEvent
    {
        /// <summary>
        /// Initializes a new instance of a mouse move event.
        /// </summary>
        /// <param name="location">The screen coordinates where this event occurred.</param>
        public MacroMouseMoveEvent(Point location) : base(location)
        {
        }
    }
}
