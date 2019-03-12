using System.Text;
using System.Xml;

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
            // Straight to superclass constructor
        }

        /// <summary>
        /// Initializes a new instance of a macro key up event.
        /// </summary>
        /// <param name="element">The serialized XML element to initialize from.</param>
        public MacroKeyUpEvent(XmlElement element) : base(0)
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "VirtualKeyCode":
                        VirtualKeyCode = int.Parse(e.InnerText);
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
            sb.AppendLine("<MacroKeyUpEvent>");
            sb.AppendLine("<VirtualKeyCode>" + VirtualKeyCode.ToString() + "</VirtualKeyCode>");
            sb.AppendLine("</MacroKeyUpEvent>");

            return sb.ToString();
        }
    }
}
