using DryIoc;

namespace Compori.Alphaplan.Plugin.Actions.DryIoc
{
    public static class Registration
    {
        /// <summary>
        /// Register the support Namespace.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        public static void Register(IRegistrator registrator)
        {
            if (registrator == null)
            {
                return;
            }

            registrator.Register<RequestFactory>(reuse: Reuse.Singleton);
            registrator.Register<Dispatcher>(reuse: Reuse.Singleton);
        }

        /// <summary>
        /// Registers the resolver.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="container">The container.</param>
        public static void RegisterResolver(IRegistrator registrator, IContainer container)
        {
            Guard.AssertArgumentIsNotNull(registrator, nameof(registrator));
            Guard.AssertArgumentIsNotNull(container, nameof(container));

            registrator.UseInstance<IRequestResolver>(new RequestResolver(container));
        }

        /// <summary>
        /// Registers the resolver.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void RegisterResolver(IContainer container)
        {
            RegisterResolver(container, container);
        }

        /// <summary>
        /// Registers the action.
        /// </summary>
        /// <typeparam name="TAction">The type of the t action.</typeparam>
        /// <typeparam name="TRequest">The type of the t action option.</typeparam>
        /// <param name="registrator">The registrator.</param>
        /// <param name="verb">The verb.</param>
        public static void RegisterAction<TAction, TRequest>(IRegistrator registrator, string verb) where TRequest : IRequest
        {
            if (registrator == null)
            {
                return;
            }
            registrator.Register<IRequest, TRequest>(serviceKey: verb);
            registrator.Register<TAction>();
        }

        /// <summary>
        /// Registers the testing actions.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        public static void RegisterTestingActions(IRegistrator registrator)
        {
            if (registrator == null)
            {
                return;
            }

            // Testing
            RegisterAction<Testing.EchoAction, Testing.EchoRequest>(registrator, Testing.EchoRequest.RequestName);
            RegisterAction<Testing.LoggingAction, Testing.LoggingRequest>(registrator, Testing.LoggingRequest.RequestName);
        }
    }
}
