using Base;
using Base.ApServer;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version2100287
{
    public class ApServerFactory
    {
        /// <summary>
        /// Gets the alphaplan plugin.
        /// </summary>
        /// <value>The alphaplan plugin.</value>
        private PluginBase Plugin { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApServerFactory"/> class.
        /// </summary>
        /// <param name="plugin">The plugin.</param>
        protected ApServerFactory(PluginBase plugin)
        {
            this.Plugin = plugin;
        }

        /// <summary>
        /// Creates the ILogin API.
        /// </summary>
        /// <returns>ILogin.</returns>
        public ILogin CreateLogin()
        {
            return this.Plugin.ManagedObject(Names.Login) as ILogin;
        }

        /// <summary>
        /// Creates the IReader API.
        /// </summary>
        /// <returns>IReader.</returns>
        public IReader CreateReader()
        {
            return this.Plugin.ManagedObject(Names.Reader) as IReader;
        }

        /// <summary>
        /// Creates the IService API.
        /// </summary>
        /// <returns>IService.</returns>
        public IService CreateService()
        {
            return this.Plugin.ManagedObject(Names.Service) as IService;
        }

        /// <summary>
        /// Creates the IWriter API.
        /// </summary>
        /// <returns>IWriter.</returns>
        public IWriter CreateWriter()
        {
            return this.Plugin.ManagedObject("Writer") as IWriter;
        }
    }
}
