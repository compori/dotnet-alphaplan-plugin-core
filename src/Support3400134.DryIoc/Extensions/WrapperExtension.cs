using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class WrapperExtension
    {
        /// <summary>
        /// Register the support of the wrappers APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithWrappers(this IRegistrator registrator)
        {
            return registrator?
                .WithWrappersVersion2850200()
                .WithWrappersVersion3400134();
        }
    }
}
