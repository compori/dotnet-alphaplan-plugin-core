namespace Compori.Alphaplan.Plugin.Actions.Testing
{
    public class LoggingAction
    {
        /// <summary>
        /// Liefert den Logger zurück.
        /// </summary>
        /// <value>Der Logger.</value>
        private static NLog.Logger Log { get; } = NLog.LogManager.GetCurrentClassLogger();

        // ReSharper disable once MemberCanBeMadeStatic.Global
#pragma warning disable CA1822 // Mark members as static
        /// <summary>
        /// Führt die Aktion mit der angegebenen Nachricht aus.
        /// </summary>
        /// <param name="message">Die Nachricht.</param>
        public void Execute(string message)
#pragma warning restore CA1822 // Mark members as static
        {
            Log.Trace(message);
            Log.Debug(message);
            Log.Info(message);
            Log.Warn(message);
            Log.Error(message);
            Log.Fatal(message);
        }
    }
}
