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
    }
}
