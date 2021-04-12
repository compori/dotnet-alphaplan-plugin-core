using System;
using System.Collections.Generic;

namespace Compori.Alphaplan.Plugin.Actions
{
    public class FailureResponse : Response
    {
        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailureResponse"/> class.
        /// </summary>
        /// <param name="request">The originated request.</param>
        /// <param name="message">The message.</param>
        public FailureResponse(IRequest request, string message) : base(request, false)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailureResponse"/> class.
        /// </summary>
        /// <param name="request">The originated request.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public FailureResponse(IRequest request, string message, Exception exception) : base(request, false)
        {
            Message = message;
            Exception = exception;
        }

        /// <summary>
        /// Liefert ein Array mit Ergebnisdaten zurück.
        /// </summary>
        /// <value>Das Ergebnis.</value>
        public override IDictionary<string, string> Result {
            get
            {
                var result = base.Result;
                result
                    .Add("failureMessage", (this.Message ?? ""));

                if (this.Exception == null)
                {
                    return result;
                }

                result.Add("exception.Message", this.Exception.Message);
                result.Add("exception.StackTrace", this.Exception.StackTrace);
                return result;
            }
        }
    }
}
