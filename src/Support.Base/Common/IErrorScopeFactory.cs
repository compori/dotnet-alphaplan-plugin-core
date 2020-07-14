namespace Compori.Alphaplan.Plugin.Support.Common
{
    public interface IErrorScopeFactory
    {
        /// <summary>
        /// Erstellt ein neues Error Scope objekt.
        /// </summary>
        /// <returns>IErrorScope.</returns>
        IErrorScope Create();

        /// <summary>
        /// Erstellt ein neues Error Scope Objekt basierend auf den übergebenen ClientBase.
        /// </summary>
        /// <param name="clientBase">The client base.</param>
        IErrorScope Create(object clientBase);
    }
}
