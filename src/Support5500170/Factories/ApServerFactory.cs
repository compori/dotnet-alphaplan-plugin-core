using Base.ApServer;
using Base.Plugins;
using Names = Base.ApServer.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class ApServerFactory
    {
        /// <summary>
        /// Gets the alphaplan manager.
        /// </summary>
        /// <value>The alphaplan manager.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        protected IManagerPlugins Manager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApServerFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ApServerFactory(IManagerPlugins manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// Creates the ILizenzInfo API.
        /// </summary>
        /// <returns>Base.ApServer.ILizenzInfo.</returns>
        public ILizenzInfo CreateLizenzInfo()
        {
            return this.Manager.ManagedObject(Names.LizenzInfo) as ILizenzInfo;
        }

        /// <summary>
        /// Creates the ILogin API.
        /// </summary>
        /// <returns>Base.ApServer.ILogin.</returns>
        public ILogin CreateLogin()
        {
            return this.Manager.ManagedObject(Names.Login) as ILogin;
        }

        /// <summary>
        /// Creates the IReader API.
        /// </summary>
        /// <returns>Base.ApServer.IReader.</returns>
        public IReader CreateReader()
        {
            return this.Manager.ManagedObject(Names.Reader) as IReader;
        }

        /// <summary>
        /// Creates the ISemaphore API.
        /// </summary>
        /// <returns>Base.ApServer.ISemaphore.</returns>
        public ISemaphore CreateSemaphore()
        {
            return this.Manager.ManagedObject(Names.Semaphore) as ISemaphore;
        }

        /// <summary>
        /// Creates the IService API.
        /// </summary>
        /// <returns>Base.ApServer.IService.</returns>
        public IService CreateService()
        {
            return this.Manager.ManagedObject(Names.Service) as IService;
        }

        /// <summary>
        /// Creates the IWriter API.
        /// </summary>
        /// <returns>Base.ApServer.IWriter.</returns>
        public IWriter CreateWriter()
        {
            return this.Manager.ManagedObject(Names.Writer) as IWriter;
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
