using Compori.Text.VariableParametersParser;
using System.Threading;

namespace Compori.Alphaplan.Plugin.Actions
{
    public interface IRequest
    {
        /// <summary>
        /// Gets the name of the request.
        /// </summary>
        /// <value>The request's name.</value>
        string Name { get; }

        /// <summary>
        /// Gets an optional serial of the request.
        /// </summary>
        /// <value>The request's serial.</value>
        string Serial { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        ParserResult Arguments { get; set; }

        /// <summary>
        /// Invokes this action instance.
        /// </summary>
        void Invoke();

#if NET40_OR_GREATER

        /// <summary>
        /// Invokes this action instance.
        /// </summary>
        /// <param name="token">A cancel token</param>
        void Invoke(CancellationToken token);

#endif

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        IResponse Response { get; }
    }
}
