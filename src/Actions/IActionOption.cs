using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public interface IActionOption
    {
        /// <summary>
        /// Gets the action verb.
        /// </summary>
        /// <value>The action verb.</value>
        string Verb { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        ParserResult Arguments { get; set; }

        /// <summary>
        /// Invokes this action instance.
        /// </summary>
        void Invoke();
    }
}
