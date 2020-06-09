using System.Globalization;
using System.Text;
using Compori.Alphaplan.Plugin.Support.Common;

namespace Compori.Alphaplan.Plugin.Actions.Testing
{
    public class LoggingActionOption : ActionOption
    {
        /// <summary>
        /// Der Name der Aktion
        /// </summary>
        public const string Name = "testing.logging";

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
        private LoggingAction Action { get; }

        /// <summary>
        /// Liefert die Api für das Alphaplan Schnittstellen Protokoll.
        /// </summary>
        /// <value>Das Alphaplan Schnittstellen Protokoll.</value>
        private IProtocol Protocol { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingActionOption"/> class.
        /// </summary>
        /// <param name="protocol">Das Alphaplan Schnittstellen Protokoll.</param>
        /// <param name="action">Die Aktion.</param>
        public LoggingActionOption(IProtocol protocol, LoggingAction action)
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

            this.Action.Execute(this.Message ?? "Test Test Test");
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
