using System.Text;
using System.Windows;
using System.Xml;

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

        /// <summary>
        /// Initializes a new instance of a mouse wheel event.
        /// </summary>
        /// <param name="element">The serialized XML element to initialize from.</param>
        public MacroMouseWheelEvent(XmlElement element) : base(new Point(0, 0))
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "Location":
                        Location = Point.Parse(e.InnerText);
                        break;
                    case "Delta":
                        Delta = int.Parse(e.InnerText);
                        break;
                }
            }
        }

        /// <summary>
        /// Serializes this object to an XML string for saving.
        /// </summary>
        /// <returns></returns>
        public override string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MacroMouseWheelEvent>");
            sb.AppendLine("<Location>" + Location.ToString() + "</Location>");
            sb.AppendLine("<Delta>" + Delta.ToString() + "</Delta>");
            sb.AppendLine("</MacroMouseWheelEvent>");

            return sb.ToString();
        }
    }
}
