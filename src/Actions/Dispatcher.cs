using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
#if !NET35
using System.Globalization;
#endif
using System.Text;
using System.Threading;
using Compori.Alphaplan.Plugin.Support.Common;
using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public class Dispatcher
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
        private RequestFactory Factory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dispatcher"/> class.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// /// <param name="factory">Die action option factory.</param>
        public Dispatcher(IProtocol protocol, RequestFactory factory)
        {
            this.Protocol = protocol;
            this.Factory = factory;
        }

        /// <summary>
        /// Returns the requests arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>ParserResult.</returns>
        public static ParserResult GetRequestArguments(IEnumerable<string> arguments)
        {
            var parser = new Parser();
            return parser.Parse(arguments.ToList(), true, true);
        }

        /// <summary>
        /// Gets the name of the request.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>System.String.</returns>
        public static string GetRequestName(ParserResult arguments)
        {
            return arguments?.GetValue("AKTION", "");
        } 

        /// <summary>
        /// Creates the request from a list of arguments.
        /// </summary>
        /// <param name="arguments">The arguments list.</param>
        /// <returns>IRequest.</returns>
        public IRequest CreateRequest(IEnumerable<string> arguments)
        {
            var result = GetRequestArguments(arguments);
            return this.Factory.Create(GetRequestName(result), result);
        }

        /// <summary>
        /// Creates the request from parsed arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>IRequest.</returns>
        public IRequest CreateRequest(ParserResult arguments)
        {
            return this.Factory.Create(GetRequestName(arguments), arguments);
        }

        /// <summary>
        /// Dispatches an action with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="fallbackArguments">The fallback arguments.</param>
        /// <returns>IResponse.</returns>
        public IResponse Dispatch(IEnumerable<string> arguments, IEnumerable<string> fallbackArguments = null)
        {
            
            var requestArguments = GetRequestArguments(arguments);
            var requestName = GetRequestName(requestArguments);
            var request = this.CreateRequest(requestArguments);

            if (request != null)
            {
                return this.Dispatch(request);
            }

            // Request could not be found.
            var sb = new StringBuilder();
            sb.AppendLine(!string.IsNullOrEmpty(requestName) 
                    ? $"Die Aktion '{requestName}' ist unbekannt. Bitte prüfen Sie den Namen." 
                    : "Es konnte keine Aktion ermittelt werden. Bitte prüfen Sie in der Parameterübergabe den Wert für 'aktion=...'.");

            if (fallbackArguments != null)
            {
                requestArguments = GetRequestArguments(fallbackArguments);
                requestName = GetRequestName(requestArguments);
                request = this.CreateRequest(requestArguments);
                
                if (request != null)
                {
                    sb.AppendLine($"Starte die Fallbackaktion '{request.Name}'.");
                    this.Protocol.Info(sb.ToString());

                    return this.Dispatch(request);
                }

                sb.AppendLine(!string.IsNullOrEmpty(requestName) 
                        ? $"Die Fallbackaktion '{requestName}' ist unbekannt. Bitte prüfen Sie den Namen." 
                        : "Es konnte keine Fallbackaktion ermittelt werden. Bitte prüfen Sie in der Parameterübergabe den Wert für 'aktion=...'.");
            }

            
            this.Protocol.Error("[Fehler] "+ sb);
            return new FailureResponse(null, sb.ToString());
        }

        /// <summary>
        /// Dispatches the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IResponse.</returns>
        public IResponse Dispatch(IRequest request)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Schreibe die Aufrufparameter
                this.Protocol.Info($"Starte Aktion '{request.Name}'");
                request.Invoke();
                return request.Response ?? new SuccessResponse(request);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                this.Protocol.Error(ex);
                return new FailureResponse(request, ex.Message, ex);
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
#if NET35
                this.Protocol.Info($"Aktion '{request.Name}' beendet. Ausführungsdauer: {stopwatch.Elapsed}");
#else       
                this.Protocol.Info($"Aktion '{request.Name}' beendet. Ausführungsdauer: {stopwatch.Elapsed.ToString("g", CultureInfo.InvariantCulture)}");
#endif
            }
        }


#if NET40_OR_GREATER

        /// <summary>
        /// Dispatches an action with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="token">A cancel token.</param>
        /// <param name="fallbackArguments">The fallback arguments.</param>
        /// <returns>IResponse.</returns>
        public IResponse Dispatch(IEnumerable<string> arguments, CancellationToken token, IEnumerable<string> fallbackArguments = null)
        {
            
            var requestArguments = GetRequestArguments(arguments);
            var requestName = GetRequestName(requestArguments);
            var request = this.CreateRequest(requestArguments);

            if (request != null)
            {
                return this.Dispatch(request, token);
            }

            // Request could not be found.
            var sb = new StringBuilder();
            sb.AppendLine(
                ! string.IsNullOrEmpty(requestName) 
                    ? $"Die Aktion '{requestName}' ist unbekannt. Bitte prüfen Sie den Namen." 
                    : "Es konnte keine Aktion ermittelt werden. Bitte prüfen Sie in der Parameterübergabe den Wert für 'aktion=...'.");
            if (fallbackArguments != null)
            {
                requestArguments = GetRequestArguments(fallbackArguments);
                requestName = GetRequestName(requestArguments);
                request = this.CreateRequest(requestArguments);
                
                if (request != null)
                {
                    sb.AppendLine($"Starte die Fallbackaktion '{request.Name}'.");
                    this.Protocol.Info(sb.ToString());

                    return this.Dispatch(request, token);
                }

                sb.AppendLine(!string.IsNullOrEmpty(requestName) 
                    ? $"Die Fallbackaktion '{requestName}' ist unbekannt. Bitte prüfen Sie den Namen." 
                    : "Es konnte keine Fallbackaktion ermittelt werden. Bitte prüfen Sie in der Parameterübergabe den Wert für 'aktion=...'.");
            }
            
            this.Protocol.Error("[Fehler] "+ sb);
            return new FailureResponse(null, sb.ToString());
        }

        /// <summary>
        /// Dispatches the specified request with cancel token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="token">A cancel token.</param>
        /// <returns>IResponse.</returns>
        public IResponse Dispatch(IRequest request, CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Schreibe die Aufrufparameter
                this.Protocol.Info($"Starte Aktion '{request.Name}'");
                request.Invoke(token);
                return request.Response ?? new SuccessResponse(request);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                this.Protocol.Error(ex);
                return new FailureResponse(request, ex.Message, ex);
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
                this.Protocol.Info($"Aktion '{request.Name}' beendet. Ausführungsdauer: {stopwatch.Elapsed.ToString("g", CultureInfo.InvariantCulture)}");
            }
        }
#endif
    }
}
