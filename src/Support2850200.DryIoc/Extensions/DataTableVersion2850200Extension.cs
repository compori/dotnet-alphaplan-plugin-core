using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class DataTableVersion2850200Extension
    {
        /// <summary>
        /// Register the the data table support for version 2850.200.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithDataTableVersion2850200(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }
            
            registrator.Register<Data.ITableFactory, Data.TableFactory>(reuse: Reuse.Singleton);
            registrator.Register<Data.IWriterFactory, Data.Version2850200.WriterFactory>(reuse: Reuse.Singleton);

            return registrator;
        }
    }
}
