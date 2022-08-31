using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public class ProtocolProvider : IProtocolProvider, IDisposable
    {
        /// <summary>
        /// Gets or sets the Alphaplan Protokoll Wrapper.
        /// </summary>
        /// <value>The Alphaplan Protokoll Wrapper.</value>
        private Base.Wrapper.Protokoll Protokoll { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolProvider"/> class.
        /// </summary>
        /// <param name="protokoll">The Alphaplan Protokoll Wrapper.</param>
        protected ProtocolProvider(Base.Wrapper.Protokoll protokoll)
        {
            this.Protokoll = protokoll;
        }

        /// <summary>
        /// Initialize the protocol provider.
        /// </summary>
        /// <param name="name">The protocol name e.g. plugin name.</param>
        /// <param name="version">The version of plugin.</param>
        /// <param name="startParameter">The start parameter</param>
        /// <param name="fileName">The filename e.g. the plugin assembly.</param>
        void IProtocolProvider.Init(string name, string version, string startParameter, string fileName)
        {
            this.Protokoll.OpenDb(name, version, startParameter, fileName);
        }

        /// <summary>
        /// Writes the specified priority.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void IProtocolProvider.Write(ProtocolPriority priority, string message, Exception exception)
        {
            var exceptionText = exception != null ? $"[Exception]: {exception.Message}\n[Exception]: Stacktrace - {exception.StackTrace}" : "";
            var messageText = message;


            int priorityValue;
            switch (priority)
            {
                case ProtocolPriority.Debug:
                    priorityValue = 4;
                    break;
                case ProtocolPriority.Informational:
                    priorityValue = 3;
                    break;
                case ProtocolPriority.Warning:
                    priorityValue = 2;
                    messageText = "WARNUNG: "
                                  + (message ?? (exception != null ? "Ein Ausnahme ist aufgetreten. " + exception.Message : "Unbekannter Fehler"))
                                  + (exception == null ? "" : $"\n{exceptionText}");
                    break;
                case ProtocolPriority.Error:
                    priorityValue = 1;
                    messageText = "FEHLER: "
                                  + (message ?? (exception != null ? "Ein Ausnahme ist aufgetreten. " + exception.Message : "Unbekannter Fehler"))
                                  + (exception == null ? "" : $"\n{exceptionText}");
                    break;
                case ProtocolPriority.None:
                    priorityValue = 0;
                    break;
                default:
                    priorityValue = 0;
                    break;
            }
            this.Protokoll.WriteDb(messageText, priorityValue, 0);
        }

        #region IDisposable Support

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;

        // ReSharper disable once UnusedParameter.Global
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            this.Protokoll.CloseDb();
            this.Protokoll = null;
            _disposedValue = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}