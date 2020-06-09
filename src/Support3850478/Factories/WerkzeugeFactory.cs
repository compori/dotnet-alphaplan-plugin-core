using Base.Plugins;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class WerkzeugeFactory : Version2850200.WerkzeugeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WerkzeugeFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public WerkzeugeFactory(IManagerPlugins manager) : base(manager)
        {
        }
    }
}
