namespace Compori.Alphaplan.Plugin.Support.Common
{
    public class ProtocolProvider : Version2850200.ProtocolProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolProvider"/> class.
        /// </summary>
        /// <param name="protokoll">The Alphaplan Protokoll Wrapper.</param>
        public ProtocolProvider(Base.Wrapper.Protokoll protokoll) : base(protokoll)
        {
        }
    }
}
