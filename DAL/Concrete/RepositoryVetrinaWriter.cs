using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.DAL.Models;
using PastryShopApi.Exceptions;
using PastryShopApi.ModelPastryShop;
using System;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class RepositoryVetrinaWriter : IVetrinaDolciWriter
    {
        private readonly IMapper _mapper;
        private readonly PastryShopContext _ctx;

        public RepositoryVetrinaWriter(IMapper mapper, ModelPastryShop.PastryShopContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public int Add(DataInsertDolceVetrina data)
        {
            var dolce = new DolciInVenditum()
            {
                DataMessaInVendita = DateTime.Now,
                Disponibilita = data.Disponibilita,
                IdDolce = data.IdDolce
            };

            _ctx.DolciInVendita.Add(dolce);

            _ctx.SaveChanges();

            return dolce.Id;
        }

        public DolciInVenditum Delete(int id)
        {
            var dolce = _ctx.DolciInVendita
                .Where(x=>!x.Scaduto.Value)
                .Include(x => x.IdDolceNavigation)
                .FirstOrDefault(x => x.Id == id);

            if (dolce == null)
                throw new EntityNotFoundException(id.ToString(), "Lotto non trovato.");

            _ctx.Remove(dolce);
            _ctx.SaveChanges();

            return dolce;
        }

        public ModelPastryShop.DolciInVenditum Update(DataUpdateDolceVetrina data)
        {
            var dolce = _ctx.DolciInVendita
                .Include(x=>x.IdDolceNavigation)
                .Where(x=>!x.Scaduto.Value)
                .FirstOrDefault(x => x.Id == data.IdDolceVetrina);

            if (dolce == null)
                throw new EntityNotFoundException(data.IdDolceVetrina.ToString(), "Lotto non trovato.");

            var rimanenza = dolce.Disponibilita - data.NumeroDolciDaVendere;
            if (rimanenza < 0)
                throw new UnderZeroException("Quantità non sufficiente.");

            dolce.Disponibilita = rimanenza;
            _ctx.SaveChanges();

            return dolce;
        }
    }
}
