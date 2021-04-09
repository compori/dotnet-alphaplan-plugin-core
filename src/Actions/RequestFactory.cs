using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public class RequestFactory
    {
        /// <summary>
        /// Gets the action option resolver.
        /// </summary>
        /// <value>The action option resolver.</value>
        private IRequestResolver Resolver { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestFactory"/> class.
        /// </summary>
        /// <param name="resolver">The action option resolver.</param>
        public RequestFactory(IRequestResolver resolver)
        {
            this.Resolver = resolver;
        }

        /// <summary>
        /// Creates a action option object based upon specific action verb.
        /// </summary>
        /// <param name="verb">The action verb.</param>
        /// <param name="parserResult">The argument parser results.</param>
        /// <returns>Request.</returns>
        public IRequest Create(string verb, ParserResult parserResult)
        {
            if (string.IsNullOrEmpty(verb))
            {
                return null;
            }
            var request = this.Resolver.Resolve(verb);
            if (request == null)
            {
                return null;
            }

            request.Arguments = parserResult;
            return request;
        }
    }
}
