using System;
using System.Collections.Generic;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public class Protocol : IProtocol
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        private IEnumerable<IProtocolProvider> Providers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Protocol"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public Protocol(IEnumerable<IProtocolProvider> providers)
        {
            this.Providers = providers;
        }

        /// <summary>
        /// Writes the specified message in protocol providers.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void Write(ProtocolPriority priority, string message, Exception exception)
        {
            foreach (var provider in this.Providers)
            {
                try
                {
                    provider.Write(priority, message, exception);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception)
                {
                    // ignored
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }                
        }

        /// <summary>
        /// Initialize the protocol.
        /// </summary>
        /// <param name="name">The protocol name e.g. plugin name.</param>
        /// <param name="version">The version of plugin.</param>
        /// <param name="startParameter">The start parameter</param>
        /// <param name="fileName">The filename e.g. the plugin assembly.</param>
        void IProtocol.Init(string name, string version, string startParameter, string fileName)
        {
            foreach (var provider in this.Providers)
            {
                try
                {
                    provider.Init(name, version, startParameter, fileName);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception)
                {
                    // ignored
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }

        /// <summary>
        /// Writes a message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void IProtocol.Write(string message)
        {
            this.Write(ProtocolPriority.None, message, null);
        }

        /// <summary>
        /// Writes a debug message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void IProtocol.Debug(string message)
        {
            this.Write(ProtocolPriority.Debug, message, null);
        }

        /// <summary>
        /// Writes an info message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void IProtocol.Info(string message)
        {
            this.Write(ProtocolPriority.Informational, message, null);
        }

        /// <summary>
        /// Writes a warning message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void IProtocol.Warn(string message)
        {
            this.Write(ProtocolPriority.Warning, message, null);
        }

        /// <summary>
        /// Writes an error message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        void IProtocol.Error(string message)
        {
            this.Write(ProtocolPriority.Error, message, null);
        }

        /// <summary>
        /// Writes an error exception into protocol.
        /// </summary>
        /// <param name="exception">The Exception.</param>
        void IProtocol.Error(Exception exception)
        {
            this.Write(ProtocolPriority.Error, null, exception);

        }

        /// <summary>
        /// Writes an error exception with message into protocol.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void IProtocol.Error(string message, Exception exception)
        {
            this.Write(ProtocolPriority.Error, message, exception);
        }
    }
}
