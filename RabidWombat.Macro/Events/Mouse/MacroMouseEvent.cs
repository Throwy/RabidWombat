using System.Windows;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse event that happens during recording.
    /// </summary>
    public abstract class MacroMouseEvent : MacroEvent
    {
        /// <summary>
        /// Gets or sets the screen coordinates where this event occurred.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Initializes a new instanceof a macro mouse event.
        /// </summary>
        /// <param name="location">The screen coordinates where the event occurred.</param>
        public MacroMouseEvent(Point location)
        {
            this.Location = location;
        }
    }
}
