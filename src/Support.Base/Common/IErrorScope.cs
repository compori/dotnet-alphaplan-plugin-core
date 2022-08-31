using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public interface IErrorScope : IDisposable
    {
        /// <summary>
        /// Liefert zurück, ob die übergebenen Ausnahme eine Alphaplan Ausnahme ist.
        /// </summary>
        /// <param name="ex">Das Ausnahmeobjekt.</param>
        /// <returns><c>true</c> wenn die übergebenen Ausnahme eine Alphaplan Ausnahme ist; andernfalls, <c>false</c>.</returns>
        bool IsAlphaplanException(Exception ex);

        /// <summary>
        /// Extrahiert die übergebenen Ausnahme und prüft, ob ein Alphaplan Fehler vorliegt und liefert diesen zurück.
        /// Falls kein Alphaplan Fehler vorliegt, wird null zurückgeliefert.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        /// <returns>ErrorException.</returns>
        ErrorException GetAlphaplanError(Exception ex);
        
        /// <summary>
        /// Extrahiert die übergebenen Ausnahme und prüft, ob ein Alphaplan Fehler vorliegt.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        void ThrowIfAlphaplanError(Exception ex);
    }
}
