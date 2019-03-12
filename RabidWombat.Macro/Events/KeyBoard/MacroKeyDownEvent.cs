using System.Text;
using System.Xml;

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
            // Straight to superclass constructor
        }

        /// <summary>
        /// Initializes a new instance of a macro key down event.
        /// </summary>
        /// <param name="element">The serialized XML element to initialize from.</param>
        public MacroKeyDownEvent(XmlElement element) : base(0)
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
            sb.AppendLine("<MacroKeyDownEvent>");
            sb.AppendLine("<VirtualKeyCode>" + VirtualKeyCode.ToString() + "</VirtualKeyCode>");
            sb.AppendLine("</MacroKeyDownEvent>");

            return sb.ToString();
        }
    }
}
