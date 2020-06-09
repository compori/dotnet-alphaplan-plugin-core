using System;
using System.Collections.Generic;
using System.Diagnostics;
#if !NET35
using System.Globalization;
#endif
using System.Text;
using Compori.Alphaplan.Plugin.Support.Common;
using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public class ActionDispatcher
    {
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
        private IProtocol Protocol { get; }

        /// <summary>
        /// Gets the action option factory.
        /// </summary>
        /// <value>The action option factory.</value>
        private ActionOptionFactory Factory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDispatcher"/> class.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// /// <param name="factory">Die action option factory.</param>
        public ActionDispatcher(IProtocol protocol, ActionOptionFactory factory)
        {
            this.Protocol = protocol;
            this.Factory = factory;
        }

        /// <summary>
        /// Dispatches an action with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public bool Dispatch(IEnumerable<string> arguments)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var parser = new Parser();
            var result = parser.Parse(new List<string>(arguments), true, true);
            var verb = result.GetValue("AKTION", "");
            var option = this.Factory.Create(verb, result);

            if(option == null)
            {
                var sb = new StringBuilder();
                sb.Append("[Fehler]");
                sb.AppendLine(string.IsNullOrEmpty(verb) 
                    ? $"Die Aktion '{verb}' ist unbekannt. Bitte prüfen Sie den Namen." 
                    : "Es konnte keine Aktion ermittelt werden. Bitte prüfen Sie in der Parameterübergabe den Wert für 'aktion=...'.");
                this.Protocol.Error(sb.ToString());
                
                return false;
            }

            try
            {
                // Schreibe die Aufrufparameter
                this.Protocol.Info($"Starte Aktion '{option.Verb}'");
                option.Invoke();
                return true;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                this.Protocol.Error(ex);
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
#if NET35
                this.Protocol.Info($"Aktion '{option.Verb}' beendet. Ausführungsdauer: {stopwatch.Elapsed}");
#else       
                this.Protocol.Info($"Aktion '{option.Verb}' beendet. Ausführungsdauer: {stopwatch.Elapsed.ToString("g", CultureInfo.InvariantCulture)}");
#endif
            }
        }
    }
}
