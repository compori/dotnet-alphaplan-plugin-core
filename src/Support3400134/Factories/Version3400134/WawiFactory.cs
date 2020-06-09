using Base.Plugins;
using Base.Wawi;
using Names = Base.Wawi.Names;

namespace Compori.Alphaplan.Plugin.Support.Factories.Version3400134
{
    public class WawiFactory : Version2850200.WawiFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WawiFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        protected WawiFactory(IManagerPlugins manager) : base(manager)
        {
        }

        /// <summary>
        /// Creates the ITexte API.
        /// </summary>
        /// <returns>ITexte.</returns>
        public ITexte CreateTexte()
        {
            return this.Manager.ManagedObject(Names.Texte) as ITexte;
        }

    }
}
