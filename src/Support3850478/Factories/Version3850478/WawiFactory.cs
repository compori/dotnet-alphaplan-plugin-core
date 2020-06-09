using Base.Plugins;
using Base.Wawi;
using Names = Base.Wawi.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version3850478
{
    public class WawiFactory : Version3400134.WawiFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WawiFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        protected WawiFactory(IManagerPlugins manager) : base(manager)
        {
        }

        /// <summary>
        /// Creates the IArtikelSet API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public IArtikelSet CreateArtikelSet()
        {
            return this.Manager.ManagedObject(Names.ArtikelSet) as IArtikelSet;
        }

        /// <summary>
        /// Creates the IBuchungsgruppe API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public IBuchungsgruppe CreateBuchungsgruppe()
        {
            return this.Manager.ManagedObject(Names.BuchungsGruppe) as IBuchungsgruppe;
        }
    }
}
