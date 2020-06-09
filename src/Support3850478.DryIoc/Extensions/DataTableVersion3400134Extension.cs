using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class DataTableVersion3400134Extension
    {
        /// <summary>
        /// Register the the data table support for version 3400.134.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithDataTableVersion3400134(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            registrator.Register<Data.ITableFactory, Data.TableFactory>(reuse: Reuse.Singleton);
            registrator.Register<Data.IWriterFactory, Data.Version3400134.WriterFactory>(reuse: Reuse.Singleton);

            return registrator;
        }
    }
}
