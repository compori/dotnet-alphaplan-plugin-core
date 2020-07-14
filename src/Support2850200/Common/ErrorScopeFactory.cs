namespace Compori.Alphaplan.Plugin.Support.Common
{
    public sealed class ErrorScopeFactory : IErrorScopeFactory
    {
        /// <summary>
        /// Das WaWi Manager Objekt
        /// </summary>
        private readonly Base.Wawi.IManagerWawi _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorScopeFactory" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ErrorScopeFactory(Base.Wawi.IManagerWawi manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ErrorHandlingScope.</returns>
        public IErrorScope Create()
        {
            return new ErrorScope(this._manager);
        }

        /// <summary>
        /// Creates the specified client base.
        /// </summary>
        /// <param name="clientBase">The client base.</param>
        /// <returns>ErrorScope.</returns>
        public IErrorScope Create(object clientBase)
        {
            return new ErrorScope((clientBase as Base.ClientBase)?.Manager as Base.Wawi.IManagerWawi ?? this._manager);
        }
    }
}
