using DryIoc;

namespace Compori.Alphaplan.Plugin.Actions.DryIoc
{
    public class RequestResolver : IRequestResolver
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        private IContainer Container { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public RequestResolver(IContainer container)
        {
            this.Container = container;
        }

        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        private IRequest Resolve(string verb)
        {
            return this.Container.Resolve<IRequest>(serviceKey: verb, ifUnresolved: IfUnresolved.ReturnDefaultIfNotRegistered);
        }

        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        IRequest IRequestResolver.Resolve(string verb)
        {
            return this.Resolve(verb);
        }
    }
}
