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
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddScoped<ICodeMasterService, CodeMasterService>();
            services.AddScoped<ICorpGroupService, CorpGroupService>();
            services.AddScoped<ICorpService, CorpService>();
            // Register other services here
        }
    }

}
