using AutoMapper;
using PastryShopApi.BL.Abstract;
using PastryShopApi.ModelPastryShop;

namespace PastryShopApi.MapperProfiles
{
    public class VetrinaDolciProfile : Profile
    {
        public VetrinaDolciProfile()
        {
            // API -> BL
            CreateMap<Models.Api.DtoInsertDolceInVetrina, BL.Models.DolceInVenditaInsert>()
                .ForMember(d => d.Disponibilita, opt => opt.MapFrom(s => s.NumeroDolciDaVendere));

            CreateMap<Models.Api.DtoUpdateDolce, BL.Models.DolceInVenditaUpdate>();

            // DAL -> BL
            CreateMap<ModelPastryShop.DolciInVenditum, PastryShopApi.BL.Models.DolceInVetrina>()
                .ForMember(d => d.IdLotto, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdDolce))
                .ForMember(d => d.Disponibilita, opt => opt.MapFrom(s => s.Disponibilita))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.IdDolceNavigation.Nome))
                .ForMember(d => d.DataMessaInVendita, opt => opt.MapFrom(s => s.DataMessaInVendita))
                .ForMember(d => d.Prezzo, opt => opt.MapFrom(s => s.IdDolceNavigation.Prezzo))
                .ForMember(d => d.PrezzoScontato, opt => opt.MapFrom<ResolvePrezzo>());

            // BL -> DAL
            CreateMap<BL.Models.DolceInVenditaInsert, DAL.Models.DataInsertDolceVetrina>();
            CreateMap<BL.Models.DolceInVenditaUpdate, DAL.Models.DataUpdateDolceVetrina>();

            // BL -> API
            CreateMap<BL.Models.DolceInVetrina, Models.Api.DolceInVetrina>();
        }
    }

    public class ResolvePrezzo : IValueResolver<ModelPastryShop.DolciInVenditum, BL.Models.DolceInVetrina, decimal>
    {
        private readonly ICalcolatorePrezzo _calcolatorePrezzo;

        public ResolvePrezzo(ICalcolatorePrezzo calcolatorePrezzo)
        {
            _calcolatorePrezzo = calcolatorePrezzo;
        }

        public decimal Resolve(DolciInVenditum source, BL.Models.DolceInVetrina destination, decimal destMember, ResolutionContext context)
        {
            if (!source.DataMessaInVendita.HasValue)
                source.DataMessaInVendita = new System.DateTime(1900, 1, 1);

            return _calcolatorePrezzo.Calcola(source.DataMessaInVendita.Value, source.IdDolceNavigation.Prezzo);
        }
    }


}