using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse button down event that occurs during recording.
    /// </summary>
    public class MacroMouseDownEvent : MacroMouseEvent
    {
        /// <summary>
        /// Gets or sets the mouse button associated with the event.
        /// </summary>
        public MouseButtons Button { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro mouse down event.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="button"></param>
        public MacroMouseDownEvent(Point location, MouseButtons button) : base(location)
        {
            this.Button = button;
        }

        /// <summary>
        /// Initializes a new instance of a macro mouse down event.
        /// </summary>
        /// <param name="element">The serialized XML element to instialize from.</param>
        public MacroMouseDownEvent(XmlElement element) : base(new Point(0, 0))
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "Location":
                        var coords = e.InnerText.Split(',');
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);
                        Location = new Point(x, y);
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
            sb.AppendLine("<MacroMouseDownEvent>");
            sb.AppendLine("<Location>" + Location.ToString() + "</Location>");
            sb.AppendLine("<Button>" + Button.ToString() + "</Button>");
            sb.AppendLine("</MacroMouseDownEvent>");

            return sb.ToString();
        }
    }
}
