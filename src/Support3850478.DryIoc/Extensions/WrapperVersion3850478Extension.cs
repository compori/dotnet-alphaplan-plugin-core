using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class WrapperVersion3850478Extension
    {
        /// <summary>
        /// Register the support of the wrappers APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithWrappersVersion3850478(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            registrator.Register<Base.Wrapper.Service>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );
            registrator.Register<Base.Wrapper.Tools>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );

            return registrator;
        }
    }
}
