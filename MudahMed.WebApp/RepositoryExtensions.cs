using Microsoft.AspNetCore.DataProtection.Repositories;
using MudahMed.Data.Repositories;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Services;
using MudahMed.Services.Abstract;
using NuGet.Protocol.Core.Types;

namespace MudahMed.WebApp
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IClinicUserRepository, ClinicUserRepository>();
            services.AddScoped<ICorpUserRepository, CorpUserRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<ICodeMasterRepository, CodeMasterRepository>();
            // Register other repositories here
        }
    }
}
