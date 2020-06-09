namespace Compori.Alphaplan.Plugin.Actions
{
    public interface IActionOptionResolver
    {
        /// <summary>
        /// Resolves the action option for a specific verb.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns>IActionOption.</returns>
        IActionOption Resolve(string verb);
    }
}
