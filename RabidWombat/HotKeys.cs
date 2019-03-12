namespace RabidWombat
{
    /// <summary>
    /// Represents a container for the applications Hot Keys.
    /// </summary>
    internal class HotKeys
    {
        /// <summary>
        /// The key to start recording a macro.
        /// </summary>
        public string StartRecordKey { get; set; }

        /// <summary>
        /// The key to stop recording a macro.
        /// </summary>
        public string StopRecordKey { get; set; }

        /// <summary>
        /// The key to start playing a macro.
        /// </summary>
        public string PlayMacroKey { get; set; }

        /// <summary>
        /// The key to stop playing a macro.
        /// </summary>
        public string StopMacroKey { get; set; }

        /// <summary>
        /// Initializes a new instance of HotKeys.
        /// </summary>
        /// <param name="startRecordKey"></param>
        /// <param name="stopRecordKey"></param>
        /// <param name="playMacroKey"></param>
        /// <param name="stopMacroKey"></param>
        public HotKeys(string startRecordKey, string stopRecordKey, string playMacroKey, string stopMacroKey)
        {
            this.StartRecordKey = startRecordKey;
            this.StopRecordKey = stopRecordKey;
            this.PlayMacroKey = playMacroKey;
            this.StopMacroKey = stopMacroKey;
        }

        /// <summary>
        /// Initializes a new instance of HotKeys.
        /// </summary>
        public HotKeys() : this("", "", "", "")
        {
        }
    }
}
