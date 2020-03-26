using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using olShop.WebApp.Middleware;

namespace olShop.WebApp.Extensions
{
    public static class ImageResizerMiddlewareExtension
    {
        public static IServiceCollection AddImageResizer(this IServiceCollection services)
        {
            return services.AddMemoryCache();
        }

        public static IApplicationBuilder UseImageResizer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageResizerMiddleware>();
        }
    }
}
