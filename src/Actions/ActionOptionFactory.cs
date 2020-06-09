using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public class ActionOptionFactory
    {
        /// <summary>
        /// Gets the action option resolver.
        /// </summary>
        /// <value>The action option resolver.</value>
        private IActionOptionResolver Resolver { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionOptionFactory"/> class.
        /// </summary>
        /// <param name="resolver">The action option resolver.</param>
        public ActionOptionFactory(IActionOptionResolver resolver)
        {
            this.Resolver = resolver;
        }

        /// <summary>
        /// Creates a action option object based upon specific action verb.
        /// </summary>
        /// <param name="verb">The action verb.</param>
        /// <param name="parserResult">The argument parser results.</param>
        /// <returns>ActionOption.</returns>
        public IActionOption Create(string verb, ParserResult parserResult)
        {
            if (string.IsNullOrEmpty(verb))
            {
                return null;
            }
            var option = this.Resolver.Resolve(verb);
            if (option == null)
            {
                return null;
            }

            option.Arguments = parserResult;
            return option;
        }
    }
}
