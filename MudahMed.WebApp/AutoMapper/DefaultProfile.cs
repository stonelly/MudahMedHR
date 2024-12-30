using AutoMapper;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.User;

namespace MudahMed.WebApp.AutoMapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            #region JobCategory

            CreateMap<AppUser, ListEmployersViewWModel>();

            #endregion
        }
    }
}
