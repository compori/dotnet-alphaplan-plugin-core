using System.Linq;
using Compori.Alphaplan.Plugin.Support.Common;

namespace Compori.Alphaplan.Plugin.Actions.Testing
{
    public class EchoAction 
    {
        /// <summary>
        /// Liefert die Api für das Alphaplan Schnittstellen Protokoll.
        /// </summary>
        /// <value>Das Alphaplan Schnittstellen Protokoll.</value>
        private IProtocol Protocol { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EchoAction"/> class.
        /// </summary>
        /// <param name="protocol">Das Alphaplan Schnittstellen Protokoll.</param>
        public EchoAction(IProtocol protocol)
        {
            this.Protocol = protocol;
        }

        /// <summary>
        /// Echoes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Echo(string message)
        {
            this.Protocol.Info("Echo: " + new string(message.Reverse().ToArray()));
        }
    }
}
