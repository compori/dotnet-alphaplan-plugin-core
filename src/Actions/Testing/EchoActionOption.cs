using System.Globalization;
using System.Text;
using Compori.Alphaplan.Plugin.Support.Common;

namespace Compori.Alphaplan.Plugin.Actions.Testing
{
    public class EchoActionOption : ActionOption
    {
        /// <summary>
        /// Der Name der Aktion
        /// </summary>
        public const string Name = "testing.echo";

        /// <summary>
        /// Liefert den Namen der Aktion zurück.
        /// </summary>
        /// <value>Der Aktionsname.</value>
        public override string Verb => Name;

        /// <summary>
        /// Liefert oder setzt die Nachricht.
        /// </summary>
        /// <value>Die Nachricht.</value>
        private string Message { get; set; }

        /// <summary>
        /// Liefert die Aktion zurück.
        /// </summary>
        /// <value>Die Aktion.</value>
        private EchoAction Action { get; }

        /// <summary>
        /// Liefert die Api für das Alphaplan Schnittstellen Protokoll.
        /// </summary>
        /// <value>Das Alphaplan Schnittstellen Protokoll.</value>
        private IProtocol Protocol { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EchoActionOption"/> class.
        /// </summary>
        /// <param name="protocol">Das Alphaplan Schnittstellen Protokoll.</param>
        /// <param name="action">Die Aktion.</param>
        public EchoActionOption(IProtocol protocol, EchoAction action)
        {
            this.Action = action;
            this.Protocol = protocol;
        }

        /// <summary>
        /// Wird von Invoke aufgerufen.
        /// </summary>
        protected override void OnInvoke()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Parameter:");
            sb.Append(string.Format(CultureInfo.InvariantCulture, " - Nachricht _________ {0}", this.Message ?? "N/A"));
            this.Protocol.Write(sb.ToString());

            this.Action.Echo(this.Message ?? "N/A");
        }

        /// <summary>
        /// Muss von der abgeleiteten Klasse überschrieben werden, um die Parameter aus einer Liste von Werten zu ermitteln.
        /// </summary>
        protected override void Parse()
        {
            this.Message = this.Arguments.GetValue("NACHRICHT", null);
        }
    }
}
