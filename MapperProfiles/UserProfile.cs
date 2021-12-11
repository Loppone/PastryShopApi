using AutoMapper;

namespace PastryShopApi.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ModelPastryShop.Utente, PastryShopApi.BL.Models.Utente>();
        }
    }
}
