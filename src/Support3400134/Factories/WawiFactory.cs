using Base.Plugins;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class WawiFactory : Version3400134.WawiFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WawiFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public WawiFactory(IManagerPlugins manager) : base(manager)
        {
        }
    }
}
