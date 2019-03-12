using RabidWombat.Macro.Events;
using RabidWombat.Macro.Events.Keyboard;
using RabidWombat.Macro.Events.Mouse;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace RabidWombat.Macro
{
    /// <summary>
    /// Represents a recorded sequence of mouse and keyboard events.
    /// </summary>
    public class Macro
    {
        /// <summary>
        /// Holds the list of events for tis macro.
        /// </summary>
        private List<MacroEvent> events;

        /// <summary>
        /// Gets the list of events for this macro as an array.
        /// </summary>
        public MacroEvent[] Events
        {
            get { return (events == null ? null : events.ToArray()); }
        }

        /// <summary>
        /// Initializes a new instance of Macro.
        /// </summary>
        public Macro()
        {
            events = new List<MacroEvent>();
        }

        /// <summary>
        /// Adds a new event to the end of this macro.
        /// </summary>
        /// <param name="newEvent">The event to add.</param>
        public void AddEvent(MacroEvent newEvent)
        {
            events.Add(newEvent);
        }

        /// <summary>
        /// Removes all events from this macro.
        /// </summary>
        public void ClearEvents()
        {
            events.Clear();
        }

        /// <summary>
        /// Serializes this object to an XML string for saving.
        /// </summary>
        /// <returns></returns>
        public string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<RabidWombatMacro>");
            foreach (MacroEvent e in events)
            {
                sb.AppendLine(e.ToXML());
            }
            sb.AppendLine("</RabidWombatMacro>");

            return sb.ToString();
        }

        /// <summary>
        /// Saves this macro to a file at the specified path.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void Save(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ToXML());
            doc.Save(path);
        }

        /// <summary>
        /// Loads the macro file at the specified path into this object.
        /// </summary>
        /// <param name="path">The path to load the macro from.</param>
        public void Load(string path)
        {
            ClearEvents();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            foreach (XmlElement element in doc.DocumentElement)
            {
                switch (element.Name)
                {
                    case "MacroKeyDownEvent":
                        AddEvent(new MacroKeyDownEvent(element));
                        break;
                    case "MacroKeyUpEvent":
                        AddEvent(new MacroKeyUpEvent(element));
                        break;
                    case "MacroMouseDownEvent":
                        AddEvent(new MacroMouseDownEvent(element));
                        break;
                    case "MacroMouseUpEvent":
                        AddEvent(new MacroMouseUpEvent(element));
                        break;
                    case "MacroMouseMoveEvent":
                        AddEvent(new MacroMouseMoveEvent(element));
                        break;
                    case "MacroMouseWheelEvent":
                        AddEvent(new MacroMouseWheelEvent(element));
                        break;
                    case "MacroDelayEvent":
                        AddEvent(new MacroDelayEvent(element));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
