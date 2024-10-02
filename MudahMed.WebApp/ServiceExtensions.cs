using MudahMed.Services;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp
{
    // ServiceExtensions.cs
    public static class ServiceExtensions
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserService>();
            // Register other services here
        }
    }

}
