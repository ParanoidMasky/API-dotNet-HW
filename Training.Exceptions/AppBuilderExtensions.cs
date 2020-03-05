
using Microsoft.AspNetCore.Builder;

namespace Training.Exceptions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
