﻿using DryIoc;

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
            return registrator?.WithDataTableVersion3400134();
        }
    }
}
