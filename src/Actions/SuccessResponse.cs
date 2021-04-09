namespace Compori.Alphaplan.Plugin.Actions
{
    /// <summary>
    /// Class SuccessResponse.
    /// Implements the <see cref="Response" />
    /// </summary>
    /// <seealso cref="Response" />
    public class SuccessResponse : Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResponse"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public SuccessResponse(IRequest request) : base(request, true)
        {
        }
    }
}
