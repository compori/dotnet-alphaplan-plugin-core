using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public interface IProtocol
    {
        /// <summary>
        /// Initialize the protocol.
        /// </summary>
        /// <param name="name">The protocol name e.g. plugin name.</param>
        /// <param name="version">The version of plugin.</param>
        /// <param name="startParameter">The start parameter</param>
        /// <param name="fileName">The filename e.g. the plugin assembly.</param>
        void Init(string name, string version, string startParameter, string fileName);

        /// <summary>
        /// Writes a message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        /// Writes a debug message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);
        
        /// <summary>
        /// Writes an info message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Writes a warning message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(string message);

        /// <summary>
        /// Writes an error message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Writes an error exception into protocol.
        /// </summary>
        /// <param name="exception">The Exception.</param>
        void Error(Exception exception);

        /// <summary>
        /// Writes an error exception with message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Error(string message, Exception exception);
    }
}
