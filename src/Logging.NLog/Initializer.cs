using System.IO;
using System.Reflection;
using TheRealNLog = NLog;

namespace Compori.Alphaplan.Plugin.Logging.NLog
{
    /// <summary>
    /// Class Initializer.
    /// </summary>
    public static class Initializer
    {
        /// <summary>
        /// The logging facility
        /// </summary>
        private static readonly TheRealNLog.Logger Log = TheRealNLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes the NLog facility based upon the calling assembly.
        /// </summary>
        public static void Init()
        {
            var assembly = Assembly.GetCallingAssembly();

            //
            // Maybe this assembly is merged together with the original calling assembly
            //
            if (assembly.GetName().Name.Equals("Plugins"))
            {
                //
                // so the executing assembly is the original calling 
                // if the calling is the higher "Plugins" Assembly 
                // in execution order.
                //
                assembly = Assembly.GetExecutingAssembly();
            }

            Init(assembly);
        }

        /// <summary>
        /// Initializes the NLog facility based upon the assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public static void Init(Assembly assembly)
        {
            //
            // Initialize den Logger
            //
            var assemblyLocation = assembly.Location;
            var assemblyFolder = Path.GetDirectoryName(assemblyLocation);
            if (string.IsNullOrEmpty(assemblyFolder))
            {
                return;
            }

            // ReSharper disable once StringLiteralTypo
            var configurationFile = Path.GetFileNameWithoutExtension(assemblyLocation) + ".nlog.config";
            var configurationPath = Path.Combine(assemblyFolder, configurationFile);

            if (File.Exists(configurationPath))
            {
                TheRealNLog.LogManager.ThrowConfigExceptions = false;
                TheRealNLog.LogManager.Configuration = new TheRealNLog.Config.XmlLoggingConfiguration(configurationPath);
                Log.Debug($"Loaded '{configurationFile}' nlog configuration file from folder '{assemblyFolder}'.");
            }
            Log.Debug("Logger initialized.");
        }
    }
}
