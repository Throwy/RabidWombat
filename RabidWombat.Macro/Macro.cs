using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RabidWombat.Macro.Events;
using System.Collections.Generic;
using System.IO;

namespace RabidWombat.Macro
{
    /// <summary>
    /// Represents a recorded sequence of mouse and keyboard events.
    /// </summary>
    public class Macro
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Converters = { new StringEnumConverter() },
            Formatting = Formatting.Indented
        };

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
        /// Saves this macro to a file at the specified path.
        /// </summary>
        public void Save(string path)
        {
            string json = JsonConvert.SerializeObject(events, JsonSettings);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Loads the macro file at the specified path into this object.
        /// </summary>
        public void Load(string path)
        {
            ClearEvents();
            string json = File.ReadAllText(path);
            events = JsonConvert.DeserializeObject<List<MacroEvent>>(json, JsonSettings);
        }
    }
}
