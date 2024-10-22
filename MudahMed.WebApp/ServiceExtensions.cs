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
            services.AddScoped<IClinicService, ClinicService>();
            // Register other services here
        }
    }

}
