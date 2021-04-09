namespace Compori.Alphaplan.Plugin.Actions
{
    public interface IRequestResolver
    {
        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        IRequest Resolve(string verb);
    }
}
