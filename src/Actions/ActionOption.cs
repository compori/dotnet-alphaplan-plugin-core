using Compori.Text.VariableParametersParser;

namespace Compori.Alphaplan.Plugin.Actions
{
    public abstract class ActionOption : IActionOption
    {
        /// <summary>
        /// Liefert den Namen der Aktion zurück.
        /// </summary>
        /// <value>Der Aktionsname.</value>
        public abstract string Verb { get; }

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
    }
}
