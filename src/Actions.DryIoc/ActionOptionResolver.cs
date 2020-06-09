using DryIoc;

namespace Compori.Alphaplan.Plugin.Actions.DryIoc
{
    public class ActionOptionResolver : IActionOptionResolver
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        private IContainer Container { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionOptionResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ActionOptionResolver(IContainer container)
        {
            this.Container = container;
        }

        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        private IActionOption Resolve(string verb)
        {
            return this.Container.Resolve<IActionOption>(serviceKey: verb, ifUnresolved: IfUnresolved.ReturnDefaultIfNotRegistered);
        }

        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        IActionOption IActionOptionResolver.Resolve(string verb)
        {
            return this.Resolve(verb);
        }
    }
}
