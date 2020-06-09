using Base.Werkzeuge;

namespace Compori.Alphaplan.Plugin.Support.Common
{
    public class ProtocolProvider : Version2100287.ProtocolProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolProvider"/> class.
        /// </summary>
        /// <param name="protokoll">The Alphaplan Protokoll API.</param>
        public ProtocolProvider(IProtokoll protokoll) : base(protokoll)
        {
        }
    }
}
