using System.Text;
using System.Xml;

namespace RabidWombat.Macro.Events
{
    /// <summary>
    /// Represents a delay that occurs between user actions during recording of a macro.
    /// </summary>
    public class MacroDelayEvent : MacroEvent
    {
        /// <summary>
        /// Gets or sets the delay in ticks.
        /// </summary>
        public long Delay { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro delay event.
        /// </summary>
        /// <param name="delay">The delay in ticks.</param>
        public MacroDelayEvent(long delay)
        {
            this.Delay = delay;
        }

        /// <summary>
        /// Initializes a new instance of a macro delay event.
        /// </summary>
        /// <param name="element">The serialized XML element to initialize from.</param>
        public MacroDelayEvent(XmlElement element)
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "Delay":
                        Delay = int.Parse(e.InnerText);
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
            sb.AppendLine("<MacroDelayEvent>");
            sb.AppendLine("<Delay>" + Delay.ToString() + "</Delay>");
            sb.AppendLine("</MacroDelayEvent>");

            return sb.ToString();
        }
    }
}
