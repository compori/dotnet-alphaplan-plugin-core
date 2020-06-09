using System;
using Compori.Alphaplan.Plugin.Support.Common;
using TheRealNLog = NLog;

namespace Compori.Alphaplan.Plugin.Logging.NLog
{
    public class ProtocolProvider : IProtocolProvider
    {
        /// <summary>
        /// The logging facility
        /// </summary>
        private TheRealNLog.Logger Log { set; get; }

        /// <summary>
        /// Initialize the protocol provider.
        /// </summary>
        /// <param name="name">The protocol name e.g. plugin name.</param>
        /// <param name="version">The version of plugin.</param>
        /// <param name="startParameter">The start parameter</param>
        /// <param name="fileName">The filename e.g. the plugin assembly.</param>
        void IProtocolProvider.Init(string name, string version, string startParameter, string fileName)
        {
            if (this.Log == null)
            {
                this.Log = !string.IsNullOrEmpty(name) ? TheRealNLog.LogManager.GetLogger(name) : TheRealNLog.LogManager.GetCurrentClassLogger();
            }
            TheRealNLog.GlobalDiagnosticsContext.Set("name",name ?? "N/A");
            TheRealNLog.GlobalDiagnosticsContext.Set("version", version ?? "N/A");
            TheRealNLog.GlobalDiagnosticsContext.Set("startParameter", startParameter ?? "N/A");
            TheRealNLog.GlobalDiagnosticsContext.Set("fileName", fileName ?? "N/A");
        }

        /// <summary>
        /// Writes the specified priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void IProtocolProvider.Write(ProtocolPriority priority, string message, Exception exception)
        {
            switch (priority)
            {
                case ProtocolPriority.None:
                    Log.Trace(message);
                    break;
                case ProtocolPriority.Debug:
                    Log.Debug(message);
                    break;
                case ProtocolPriority.Informational:
                    Log.Info(message);
                    break;
                case ProtocolPriority.Warning:
                    Log.Warn(message);
                    break;
                case ProtocolPriority.Error:
                    if (!string.IsNullOrEmpty(message))
                    {
                        Log.Error(message);
                    }
                    if (exception != null)
                    {
                        Log.Error(exception);
                    }
                    break;
                default:
                    // quite
                    return;
            }
        }
    }
}
