using AutoMapper;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Models;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.DAL.Models;
using PastryShopApi.Exceptions;
using PastryShopApi.ModelPastryShop;
using System.Collections.Generic;

namespace PastryShopApi.BL.Concrete
{
    public class VetrinaOperations : IVetrina
    {
        private readonly IMapper _mapper;
        private readonly IReader<DolciInVenditum> _vetrinaReader;
        private readonly IVetrinaDolciWriter _vetrinaWriter;
        private readonly IReader<ModelPastryShop.Dolce> _dolciReader;

        public VetrinaOperations(IMapper mapper, IReader<DolciInVenditum> vetrinaReader, IVetrinaDolciWriter vetrinaWriter, IReader<ModelPastryShop.Dolce> dolciReader)
        {
            _mapper = mapper;
            _vetrinaReader = vetrinaReader;
            _vetrinaWriter = vetrinaWriter;
            _dolciReader = dolciReader;
        }

        public int AggiungiDolce(DolceInVenditaInsert dolce)
        {
            if (_dolciReader.Get(dolce.IdDolce) == null)
                throw new EntityNotFoundException(dolce.IdDolce.ToString(), "Dolce non trovato.");

            var mapDal = _mapper.Map<DolceInVenditaInsert, DataInsertDolceVetrina>(dolce);

            return _vetrinaWriter.Add(mapDal);
        }

        public List<PastryShopApi.BL.Models.DolceInVetrina> ListaDolci()
        {
            var dataDolci = _vetrinaReader.GetAll();

            return _mapper.Map<List<ModelPastryShop.DolciInVenditum>, List<PastryShopApi.BL.Models.DolceInVetrina>>(dataDolci);
        }

        public DolceInVetrina VendiDolce(DolceInVenditaUpdate dolce)
        {
            if (_vetrinaReader.Get(dolce.IdDolceVetrina) == null)
                throw new EntityNotFoundException(dolce.IdDolceVetrina.ToString(), "Lotto non trovato in vetrina.");

            var mapDal = _mapper.Map<DolceInVenditaUpdate, DataUpdateDolceVetrina>(dolce);

            return _mapper.Map<ModelPastryShop.DolciInVenditum, DolceInVetrina>(_vetrinaWriter.Update(mapDal));
        }

        public DolceInVetrina RimuoviDolce(int id)
        {
            if (_vetrinaReader.Get(id) == null)
                throw new EntityNotFoundException(id.ToString(), "Lotto non trovato in vetrina.");

            return _mapper.Map<ModelPastryShop.DolciInVenditum, DolceInVetrina>(_vetrinaWriter.Delete(id));
        }
    }
}
