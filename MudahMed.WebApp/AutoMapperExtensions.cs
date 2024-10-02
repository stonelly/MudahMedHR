using AutoMapper;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.Repositories;
using System.Reflection;
using MudahMed.WebApp.AutoMapper;

namespace MudahMed.WebApp
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DefaultProfile));
        }
    }
}
