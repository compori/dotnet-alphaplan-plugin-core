using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class DataTableExtension
    {
        /// <summary>
        /// Register the the data table support.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithDataTable(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            registrator.Register<Data.ITableFactory, Data.TableFactory>(reuse: Reuse.Singleton);
            registrator.Register<Data.IWriterFactory, Data.WriterFactory>(reuse: Reuse.Singleton);

            return registrator;
        }
    }
}
