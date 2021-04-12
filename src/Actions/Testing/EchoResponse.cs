using System.Collections.Generic;

namespace Compori.Alphaplan.Plugin.Actions.Testing
{
    public class EchoResponse : Response
    {
        /// <summary>
        /// Gets the echo.
        /// </summary>
        /// <value>The echo.</value>
        public string Echo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EchoResponse" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="echo">The echo.</param>
        public EchoResponse(IRequest request, string echo = null) : base(request, true)
        {
            this.Echo = echo ?? "Silence";
        }

        /// <summary>
        /// Liefert ein Array mit Ergebnisdaten zurück.
        /// </summary>
        /// <value>Das Ergebnis.</value>
        public override IDictionary<string, string> Result {
            get
            {
                var result = base.Result;
                result.Add("echo", this.Echo);
                return result;
            }
        }
    }
}
