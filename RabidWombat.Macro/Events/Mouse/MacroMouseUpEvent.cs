using System;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Xml;

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
        public MouseButtons Button { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro mouse up event.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="button"></param>
        public MacroMouseUpEvent(Point location, MouseButtons button) : base(location)
        {
            this.Button = button;
        }

        /// <summary>
        /// Initializes a new instance of a macro mouse up event.
        /// </summary>
        /// <param name="element">The serialized XML element to instialize from.</param>
        public MacroMouseUpEvent(XmlElement element) : base(new Point(0, 0))
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "Location":
                        Location = Point.Parse(e.InnerText);
                        break;
                    case "Button":
                        Button = (MouseButtons)Enum.Parse(typeof(MouseButtons), e.InnerText);
                        break;
                    default:
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
            sb.AppendLine("<MacroMouseUpEvent>");
            sb.AppendLine("<Location>" + Location.ToString() + "</Location>");
            sb.AppendLine("<Button>" + Button.ToString() + "</Button>");
            sb.AppendLine("</MacroMouseUpEvent>");

            return sb.ToString();
        }
    }
}
