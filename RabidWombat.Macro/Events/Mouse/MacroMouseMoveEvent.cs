using System.Drawing;
using System.Text;
using System.Xml;

namespace RabidWombat.Macro.Events.Mouse
{
    public class MacroMouseMoveEvent : MacroMouseEvent
    {
        /// <summary>
        /// Initializes a new instance of a mouse move event.
        /// </summary>
        /// <param name="location">The screen coordinates where this event occurred.</param>
        public MacroMouseMoveEvent(Point location) : base(location)
        {
            // Straight to superclass constructor
        }

        /// <summary>
        /// Initializes a new instance of a macro mouse move event.
        /// </summary>
        /// <param name="element">The serialized XML element to intialize from.</param>
        public MacroMouseMoveEvent(XmlElement element) : base(new Point(0, 0))
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
            sb.AppendLine("<MacroMouseMoveEvent>");
            sb.AppendLine("<Location>" + Location.ToString() + "</Location>");
            sb.AppendLine("</MacroMouseMoveEvent>");

            return sb.ToString();
        }
    }
}
