namespace RabidWombat.Macro.Events
{
    /// <summary>
    /// Represents an event that occurs during a macro.
    /// </summary>
    public abstract class MacroEvent
    {
        /// <summary>
        /// Returns a representation of this object as an XML string;
        /// </summary>
        /// <returns></returns>
        public abstract string ToXML();
    }
}
