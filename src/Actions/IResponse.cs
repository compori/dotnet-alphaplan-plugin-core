using System.Collections.Generic;

namespace Compori.Alphaplan.Plugin.Actions
{
    public interface IResponse
    {
        /// <summary>
        /// Gets the corresponding request.
        /// </summary>
        /// <value>The request.</value>
        IRequest Request { get; }

        /// <summary>
        /// Gets a value indicating whether the corresponding <see cref="IRequest"/> is succeeded.
        /// </summary>
        /// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
        bool Succeeded { get; }

        /// <summary>
        /// Liefert ein Wörterbuch mit Ergebnisdaten zurück.
        /// </summary>
        /// <value>Das Ergebnis.</value>
        IDictionary<string, string> Result { get; }

        /// <summary>
        /// Liefert eine Liste mit Ergebnisdaten zurück.
        /// </summary>
        /// <value>Das Ergebnis.</value>
        IList<string> ResultList { get; }
    }
}
