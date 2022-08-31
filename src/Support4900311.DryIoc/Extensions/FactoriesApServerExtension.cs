using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesApServerExtension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesApServer(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            // register ApServer Factory
            registrator.Register<Factories.ApServerFactory>();

            //
            // Register ApServer APIs
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateLogin()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateReader()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateService()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateWriter()),
                setup: Setup.With(preventDisposal: true));

            //
            // Register additional ApServer API for Version 2850.200
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateLizenzInfo()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateSemaphore()),
                setup: Setup.With(preventDisposal: true));

            //
            // Register additional ApServer API for Version 3400.134
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateQuery()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}
