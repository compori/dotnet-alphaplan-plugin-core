using Base.Plugins;
using Base.Werkzeuge;
using Names = Base.Werkzeuge.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class WerkzeugeFactory
    {
        /// <summary>
        /// Gets the alphaplan manager.
        /// </summary>
        /// <value>The alphaplan manager.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        protected IManagerPlugins Manager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WerkzeugeFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public WerkzeugeFactory(IManagerPlugins manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// Creates the IProtokoll API.
        /// </summary>
        /// <returns>IProtokoll.</returns>
        public IProtokoll CreateProtokoll()
        {
            return this.Manager.ManagedObject(Names.Protokoll) as IProtokoll;
        }

        /// <summary>
        /// Creates the IStandard API.
        /// </summary>
        /// <returns>IStandard.</returns>
        public IStandard CreateStandard()
        {
            return this.Manager.ManagedObject(Names.Standard) as IStandard;
        }

        /// <summary>
        /// Creates the IStatusMonitor API.
        /// </summary>
        /// <returns>IStatusMonitor.</returns>
        public IStatusMonitor CreateStatusMonitor()
        {
            return this.Manager.ManagedObject(Names.StatusMonitor) as IStatusMonitor;
        }
    }
}
