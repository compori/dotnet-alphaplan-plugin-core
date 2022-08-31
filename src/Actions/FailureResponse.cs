using System;

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
        public FailureResponse(IRequest request, string message) : this(request, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailureResponse"/> class.
        /// </summary>
        /// <param name="request">The originated request.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public FailureResponse(IRequest request, string message, Exception exception) : base(request, false)
        {
            this.Message = message;
            this.Exception = exception;

            this.Result.Add("failureMessage", (this.Message ?? ""));
            if(exception != null)
            {
                this.Result.Add("exception.Message", this.Exception.Message);
                this.Result.Add("exception.StackTrace", this.Exception.StackTrace);
            }
        }
    }
}
