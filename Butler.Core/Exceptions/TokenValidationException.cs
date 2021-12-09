using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Butler.Tests")]
namespace Butler.Core.Exceptions
{
    internal class TokenValidationException : Exception
    {
        public TokenValidationException(string message) : base(message)
        {
        }
    }
}
