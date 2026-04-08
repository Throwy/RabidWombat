using System.Windows;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse wheel event that occurs during macro recording.
    /// </summary>
    public class MacroMouseWheelEvent : MacroMouseEvent
    {
        /// <summary>
        /// Gets or sets the delta value of the wheel rotation.
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// Initializes a new instance of a mouse wheel event.
        /// </summary>
        /// <param name="location">The screen coordinates where this event occurred.</param>
        /// <param name="delta">The delta value of the wheel rotation.</param>
        public MacroMouseWheelEvent(Point location, int delta) : base(location)
        {
            this.Delta = delta;
        }
    }
}
