using System.Threading;
using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public abstract class Request : IRequest
    {
        /// <summary>
        /// Gets the name of the request.
        /// </summary>
        /// <value>The request's name.</value>
        public abstract string Name { get; }

        /// <summary>
        /// Gets an optional serial of the request.
        /// </summary>
        /// <value>The request's serial.</value>
        public string Serial => this.Arguments?.GetValue("AKTION_SERIAL", "") ?? "";

#if NET40_OR_GREATER

        /// <summary>
        /// Gets the cancellation token of the request.
        /// </summary>
        /// <value>The request's name.</value>
        protected CancellationToken CancellationToken { get; set; }
            
#endif

        /// <summary>
        /// The arguments
        /// </summary>
        private ParserResult _arguments;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public ParserResult Arguments {
            get => this._arguments;
            set {
                Guard.AssertArgumentIsNotNull(value, nameof(value));
                this._arguments = value;
                this.Parse();
            }
        }

        /// <summary>
        /// Parses this instance.
        /// </summary>
        protected virtual void Parse() 
        {
        }

        /// <summary>
        /// Called when action is instance is invoked.
        /// </summary>
        protected abstract void OnInvoke();

        /// <summary>
        /// Invokes this action instance.
        /// </summary>
        public void Invoke()
        {
            this.OnInvoke();
        }
        
#if NET40_OR_GREATER

        /// <summary>
        /// Invokes this action instance.
        /// </summary>
        /// <param name="token">A cancel token</param>
        public void Invoke(CancellationToken token)
        {
            this.CancellationToken = token;
            this.OnInvoke();
        }

#endif

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        protected IResponse Response { get; set; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        IResponse IRequest.Response => this.Response;
    }
}
