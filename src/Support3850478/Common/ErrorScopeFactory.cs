namespace Compori.Alphaplan.Plugin.Support.Common
{
    public sealed class ErrorScopeFactory : IErrorScopeFactory
    {
        /// <summary>
        /// Das WaWi Manager Objekt
        /// </summary>
        private Base.Wawi.IManagerWawi Manager { get; }

        /// <summary>
        /// The tools
        /// </summary>
        private Base.Wrapper.Tools Tools { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorScopeFactory" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// /// <param name="tools">The tools.</param>
        public ErrorScopeFactory(Base.Wawi.IManagerWawi manager, Base.Wrapper.Tools tools)
        {
            this.Manager = manager;
            this.Tools = tools;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ErrorHandlingScope.</returns>
        public IErrorScope Create()
        {
            return new ErrorScope(this.Manager, this.Tools);
        }

        /// <summary>
        /// Creates the specified client base.
        /// </summary>
        /// <param name="clientBase">The client base.</param>
        /// <returns>ErrorScope.</returns>
        public IErrorScope Create(object clientBase)
        {
            return new ErrorScope((clientBase as Base.ClientBase)?.Manager as Base.Wawi.IManagerWawi ?? this.Manager, this.Tools);
        }
    }
}
