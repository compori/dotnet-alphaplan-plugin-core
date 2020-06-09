using Base.Plugins;

namespace Compori.Alphaplan.Plugin.Support.Factories
{
    public class ApServerFactory : Version3400134.ApServerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApServerFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ApServerFactory(IManagerPlugins manager) : base(manager)
        {
        }
    }
}
