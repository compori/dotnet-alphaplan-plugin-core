using Base.ApServer;
using Base.Plugins;
using Names = Base.ApServer.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version3400134
{
    public class ApServerFactory : Version2850200.ApServerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApServerFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        protected ApServerFactory(IManagerPlugins manager) : base(manager)
        {
        }

        /// <summary>
        /// Creates the IQuery API.
        /// </summary>
        /// <returns>Base.ApServer.IQuery.</returns>
        public IQuery CreateQuery()
        {
            return this.Manager.ManagedObject(Names.Query) as IQuery;
        }
    }
}
