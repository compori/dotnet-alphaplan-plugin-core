using System;

namespace Compori.Alphaplan.Plugin.Support.Common
{
#pragma warning disable CA2237 // Mark ISerializable types with serializable
#pragma warning disable CA1032 // Implement standard exception constructors
    public class ErrorException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
#pragma warning restore CA2237 // Mark ISerializable types with serializable
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Code { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException" /> class.
        /// </summary>
        public ErrorException(int code, string message, Exception innerException) : base(message, innerException)
        {
            this.Code = code;
        }
    }
}
