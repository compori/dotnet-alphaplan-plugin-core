using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public sealed class ErrorScope : IErrorScope, IDisposalState
    {
        /// <summary>
        /// Liefert oder setzt das WaWi Manager Objekt.
        /// </summary>
        /// <value>Das WaWi Manager Objekt.</value>
        private Base.Wawi.IManagerWawi Manager { get; set; }

        /// <summary>
        /// Speichert den vorherigen Wert für MitIgnoreListHandler im Managerobjekt
        /// </summary>
        private readonly bool _mitIgnoreListHandler;

        /// <summary>
        /// Speichert den vorherigen Wert für IgnoreAllApError im Managerobjekt
        /// </summary>
        private readonly bool _ignoreAllApError;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorScope" /> class.
        /// </summary>
        /// <param name="manager">Das WaWi Manager Objekt.</param>
        public ErrorScope(Base.Wawi.IManagerWawi manager)
        {
            this.Manager = manager;
            this._mitIgnoreListHandler = this.Manager.MitIgnoreListHandler;
            this._ignoreAllApError = this.Manager.IgnoreAllApError;
            this.Manager.MitIgnoreListHandler = false;
            this.Manager.IgnoreAllApError = true;
        }

        /// <summary>
        /// Liefert die Fehlerbeschreibung zurück.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        /// <returns>System.String.</returns>
        private static string GetErrorDescription(Exception ex)
        {
            if (ex?.Data == null)
            {
                return "";
            }
            return ex.Data.Contains("AP-Description") ? ex.Data["AP-Description"] as string : "";
        }

        /// <summary>
        /// Liefert den Fehlercode zurück.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        /// <returns>System.Int32.</returns>
        private static int GetErrorCode(Exception ex)
        {
            if (ex?.Data == null)
            {
                return 0;
            }

            // ReSharper disable StringLiteralTypo
            return ex.Data.Contains("AP-Errornumber") ? ex.Data["AP-Errornumber"] as int? ?? 0 : 0;
            // ReSharper restore StringLiteralTypo
        }

        /// <summary>
        /// Liefert zurück, ob die Ausnahme eine Alphaplan Ausnahme war.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        /// <returns><c>true</c> wenn die Ausnahme eine Alphaplan ausnahme ist; andernfalls, <c>false</c>.</returns>
        private static bool IsApObjectsException(Exception ex)
        {
            if (ex == null)
            {
                return false;
            }
            var fullName = ex.GetType().FullName;
            return fullName != null && fullName.Equals("APObjects_NET.Exception");
        }

        /// <summary>
        /// Extrahiert die übergebenen Ausnahme und prüft, ob ein Alphaplan Fehler vorliegt.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        // ReSharper disable once MemberCanBeMadeStatic.Global
#pragma warning disable CA1822 // Mark members as static
        public void ThrowIfAlphaplanError(Exception ex)
#pragma warning restore CA1822 // Mark members as static
        {
            var error = this.GetAlphaplanError(ex);

            if (error != null)
            {
                throw error;
            }
        }

        /// <summary>
        /// Extrahiert die übergebenen Ausnahme und prüft, ob ein Alphaplan Fehler vorliegt und liefert diesen zurück.
        /// Falls kein Alphaplan Fehler vorliegt, wird null zurückgeliefert.
        /// </summary>
        /// <param name="ex">Die Ausnahme.</param>
        /// <returns>ErrorException.</returns>
        public ErrorException GetAlphaplanError(Exception ex)
        {
            var message = ex.Message;
            var code = 0;

            if (IsApObjectsException(ex))
            {
                message = GetErrorDescription(ex);
                code = GetErrorCode(ex);
            }
            else if (IsApObjectsException(ex.InnerException))
            {
                message = GetErrorDescription(ex.InnerException);
                code = GetErrorCode(ex.InnerException);
            }

            return code > 0 ? new ErrorException(code, message, ex) : null;
        }

        /// <summary>
        /// Liefert zurück, ob die übergebenen Ausnahme eine Alphaplan Ausnahme ist.
        /// </summary>
        /// <param name="ex">Das Ausnahmeobjekt.</param>
        /// <returns><c>true</c> wenn die übergebenen Ausnahme eine Alphaplan Ausnahme ist; andernfalls, <c>false</c>.</returns>
        public bool IsAlphaplanException(Exception ex)
        {
            return IsApObjectsException(ex);
        }


        #region "IDisposable Support"

        /// <summary>
        /// Liefert einen Wert zurück, der angibt ob das Objekt bereits verworfen wurden <see cref="IDisposable.Dispose()" />
        /// </summary>
        /// <value><c>true</c> wenn das Objekt verworfen wurde; andernfalls, <c>false</c>.</value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        // ReSharper disable once UnusedParameter.Local
#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
        {
            if (!this.IsDisposed)
            {
                if (this.Manager != null)
                {
                    this.Manager.MitIgnoreListHandler = this._mitIgnoreListHandler;
                    this.Manager.IgnoreAllApError = this._ignoreAllApError;
                    this.Manager = null;
                }
            }
            this.IsDisposed = true;
        }

        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe
        /// oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.
            Dispose(true);
            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
