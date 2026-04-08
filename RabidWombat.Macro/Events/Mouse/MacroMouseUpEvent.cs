using System.Windows;
using System.Windows.Input;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse button up event that occurs during recording.
    /// </summary>
    public class MacroMouseUpEvent : MacroMouseEvent
    {
        /// <summary>
        /// Gets or sets the mouse button associated with the event.
        /// </summary>
        public MouseButton Button { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro mouse up event.
        /// </summary>
        public MacroMouseUpEvent(Point location, MouseButton button) : base(location)
        {
            this.Button = button;
        }
    }
}
