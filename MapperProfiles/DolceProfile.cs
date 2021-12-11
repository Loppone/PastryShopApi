using AutoMapper;

namespace PastryShopApi.MapperProfiles
{
    public class DolceProfile : Profile
    {
        public DolceProfile()
        {
            //CreateMap<BL.Models.DolceInsert, BL.Models.DolceUpdate>();


            // API -> BL
            CreateMap<Models.Api.DtoDolceInsert, PastryShopApi.BL.Models.DolceInsert>();
            CreateMap<Models.Api.DtoIngredienteUpsert, PastryShopApi.BL.Models.IngredienteUpsert>();
            CreateMap<Models.Api.DtoDolceUpdate, BL.Models.DolceUpdate>();

            // BL -> API
            CreateMap<BL.Models.Dolce, Models.Api.Dolce>();
            CreateMap<BL.Models.Ingrediente, Models.Api.Ingrediente>();
            CreateMap<BL.Models.UM, Models.Api.UM>();

            // BL -> DAL
            CreateMap<BL.Models.DolceInsert, ModelPastryShop.Dolce>()
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.Nome))
                .ForMember(d => d.Prezzo, opt => opt.MapFrom(s => s.Prezzo))
                .ForMember(d => d.IngredientiDolces, opt => opt.MapFrom(s => s.Ingredienti));

            CreateMap<BL.Models.IngredienteUpsert, ModelPastryShop.IngredientiDolce>()
                .ForMember(d => d.Quantita, opt => opt.MapFrom(s => s.Quantita))
                .ForMember(d => d.IdIngrediente, opt => opt.MapFrom(s => s.IdIngrediente));


            // DAL -> BL
            CreateMap<ModelPastryShop.Dolce, BL.Models.Dolce>()
                .ForMember(d => d.Ingredienti, opt => opt.MapFrom(s=>s.IngredientiDolces));

            CreateMap<ModelPastryShop.IngredientiDolce, BL.Models.Ingrediente>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.IdIngredienteNavigation.Nome))
                .ForMember(d => d.UnitaDiMisura, opt => opt.MapFrom(s => s.IdIngredienteNavigation.UmNavigation));

            CreateMap<ModelPastryShop.Um, BL.Models.UM>();


            // DAL --> API
            // Eccezionalmente per caricamento di elenco di valori per tendina/lista fissa...
            CreateMap<ModelPastryShop.Ingrediente, Models.Api.Ingrediente>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.Nome))
                .ForMember(d => d.UnitaDiMisura, opt => opt.MapFrom(s => s.UmNavigation));

            CreateMap<ModelPastryShop.Um, Models.Api.UM>()
                .ForMember(d => d.Sigla, opt => opt.MapFrom(s => s.Sigla))
                .ForMember(d => d.NomeCompleto, opt => opt.MapFrom(s => s.NomeCompleto));

            CreateMap<ModelPastryShop.IngredientiDolce, Models.Api.Ingrediente>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdIngrediente))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.IdIngredienteNavigation.Nome))
                .ForMember(d => d.Quantita, opt => opt.MapFrom(s => s.Quantita))
                .ForMember(d => d.UnitaDiMisura, opt => opt.MapFrom(s => s.IdIngredienteNavigation.UmNavigation));
        }
    }
}
