namespace RabidWombat
{
    /// <summary>
    /// Represents the application configuration file.
    /// </summary>
    internal class ConfigurationFile : JsonSerializable<ConfigurationFile>
    {
        /// <summary>
        /// The application's hotkey settings.
        /// </summary>
        public HotKeys HotKeys { get; set; }

        /// <summary>
        /// Initializes a instance of the application configuration file.
        /// </summary>
        public ConfigurationFile()
        {
            HotKeys = new HotKeys
            {
                StartRecordKey = "Ctrl+Q",
                StopRecordKey = "Ctrl+W",
                PlayMacroKey = "Ctrl+E",
                StopMacroKey = "Ctrl+R"
            };
        }
    }
}
