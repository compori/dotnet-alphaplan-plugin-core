using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class DataTableVersion2100287Extension
    {
        /// <summary>
        /// Register the the data table support for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithDataTableVersion2100287(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }
            registrator.Register<Data.ITableFactory, Data.TableFactory>(reuse: Reuse.Singleton);
            registrator.Register<Data.IWriterFactory, Data.Version2100287.WriterFactory>(reuse: Reuse.Singleton);

            return registrator;
        }
    }
}
