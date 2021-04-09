namespace Compori.Alphaplan.Plugin.Actions
{
    public class Response : IResponse
    {
        /// <summary>
        /// Gets the corresponding request.
        /// </summary>
        /// <value>The request.</value>
        public IRequest Request { get; }

        /// <summary>
        /// Gets a value indicating whether the corresponding <see cref="IRequest" /> is succeeded.
        /// </summary>
        /// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
        public bool Succeeded { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="request">The originated request.</param>
        /// <param name="succeeded">if set to <c>true</c> if request succeeded.</param>
        public Response(IRequest request, bool succeeded)
        {
            this.Request = request;
            this.Succeeded = succeeded;
        }
    }
}
