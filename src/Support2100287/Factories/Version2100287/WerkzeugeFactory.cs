using Base;
using Base.Werkzeuge;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version2100287
{
    public class WerkzeugeFactory
    {
        /// <summary>
        /// Gets the alphaplan plugin.
        /// </summary>
        /// <value>Der Alphaplan Plugin Manager.</value>
        private PluginBase Plugin { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WerkzeugeFactory"/> class.
        /// </summary>
        /// <param name="plugin">The plugin.</param>
        protected WerkzeugeFactory(PluginBase plugin)
        {
            this.Plugin = plugin;
        }

        /// <summary>
        /// Creates the IProtokoll API.
        /// </summary>
        /// <returns>IProtokoll.</returns>
        public IProtokoll CreateProtokoll()
        {
            return this.Plugin.ManagedObject("Protokoll") as IProtokoll;
        }

        /// <summary>
        /// Creates the IStandard API.
        /// </summary>
        /// <returns>IStandard.</returns>
        public IStandard CreateStandard()
        {
            return this.Plugin.ManagedObject("Standard") as IStandard;
        }

        /// <summary>
        /// Creates the IStatusMonitor API.
        /// </summary>
        /// <returns>IStatusMonitor.</returns>
        public IStatusMonitor CreateStatusMonitor()
        {
            return this.Plugin.ManagedObject("StatusMonitor") as IStatusMonitor;
        }
    }
}
