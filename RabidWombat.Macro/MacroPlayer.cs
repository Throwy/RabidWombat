using RabidWombat.Simulation.Mouse;
using System.Threading;

namespace RabidWombat.Macro
{
    /// <summary>
    /// Provides support for playing recorded macros.
    /// </summary>
    public class MacroPlayer
    {
        /// <summary>
        /// Holds the mouse simulator.
        /// </summary>
        private MouseSimulator mouseSimulator;

        /// <summary>
        /// Holds the thread that the macro is currently executing on.
        /// </summary>
        private Thread macroThread;

        /// <summary>
        /// Holds the execution cancel state.
        /// </summary>
        private bool cancelled;

        /// <summary>
        /// Holds the number of times the macro should repeat before ending.
        /// </summary>
        private int repetitions;

        /// <summary>
        /// Gets the macro currently loaded into the player.
        /// </summary>
        public Macro CurrentMacro { get; private set; }

        /// <summary>
        /// Gets or sets the number of times the macro should repeat before ending.
        /// </summary>
        public int Repetitions
        {
            get
            {
                return repetitions;
            }
            set
            {
                repetitions = (value == 0 ? 1 : value);
            }
        }

        /// <summary>
        /// Gets whether or not a macro is being played.
        /// </summary>
        public bool IsPlaying { get; private set; }
    }
}
