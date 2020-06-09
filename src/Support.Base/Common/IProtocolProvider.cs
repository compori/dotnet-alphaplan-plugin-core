using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public interface IProtocolProvider
    {
        /// <summary>
        /// Initialize the protocol provider.
        /// </summary>
        /// <param name="name">The protocol name e.g. plugin name.</param>
        /// <param name="version">The version of plugin.</param>
        /// <param name="startParameter">The start parameter</param>
        /// <param name="fileName">The filename e.g. the plugin assembly.</param>
        void Init(string name, string version, string startParameter, string fileName);

        /// <summary>
        /// Writes the specified priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Write(ProtocolPriority priority, string message, Exception exception);
    }
}
