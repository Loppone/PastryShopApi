using AutoMapper;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Models;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.DAL.Concrete;
using PastryShopApi.Exceptions;
using System.Collections.Generic;

namespace PastryShopApi.BL.Concrete
{
    public class DolceOperations : IDolce
    {
        private readonly IMapper _mapper;
        private readonly IReader<ModelPastryShop.Dolce> _reader;
        private readonly IDolciWriter _writer;

        public DolceOperations(IMapper mapper, IReader<ModelPastryShop.Dolce> reader, IDolciWriter writer)
        {
            _mapper = mapper;
            _reader = reader;
            _writer = writer;
        }

        public int Crea(DolceInsert payload)
        {
            if (DolciUtil.NameTaken(payload.Nome))
                throw new AlreadyExistsException();

            return _writer.Add(payload);
        }

        public List<BL.Models.Dolce> Get()
        {
            return _mapper.Map<List<ModelPastryShop.Dolce>,List<BL.Models.Dolce>>(_reader.GetAll());
        }


        public Dolce Get(int id)
        {
            return _mapper.Map<ModelPastryShop.Dolce, BL.Models.Dolce>( _reader.Get(id));
        }

        public static Dictionary<int, string> ListaDolci()
        {
            return DolciUtil.GetElencoDolci();
        }

        public Dolce Elimina(int id)
        {
            if (_reader.Get(id) == null)
                throw new EntityNotFoundException(id.ToString(), "Dolce non trovato.");

            return _mapper.Map<ModelPastryShop.Dolce, Dolce>(_writer.Delete(id));
        }

        public void Modifica(DolceUpdate payload)
        {
            _writer.Update(payload);
        }
    }
}
