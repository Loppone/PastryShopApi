using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PastryShopApi.BL.Models;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.Exceptions;
using PastryShopApi.ModelPastryShop;
using System.Collections.Generic;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class RepositoryDolceWriter : IDolciWriter
    {
        private readonly IMapper _mapper;
        private readonly PastryShopContext _ctx;

        public RepositoryDolceWriter(IMapper mapper, PastryShopContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public int Add(DolceInsert payload)
        {
            var map = _mapper.Map<DolceInsert, ModelPastryShop.Dolce>(payload);

            _ctx.Add(map);

            _ctx.SaveChanges();

            return map.Id;
        }

        public ModelPastryShop.Dolce Delete(int id)
        {
            var dolce = _ctx.Dolces
                .FirstOrDefault(x => x.Id == id);

            _ctx.Remove(dolce);
            _ctx.SaveChanges();

            return dolce;
        }

        public void Update(DolceUpdate payload)
        {
            var dolce = _ctx.Dolces
                .Include(x => x.IngredientiDolces)
                .FirstOrDefault(x => x.Id == payload.Id);

            dolce.Nome = payload.Nome;
            dolce.Prezzo = payload.Prezzo;

            var ingredientiToRemove = new List<IngredientiDolce>();
            foreach (var item in payload.Ingredienti)
            {
                var ingr = dolce.IngredientiDolces
                    .FirstOrDefault(x => x.IdIngrediente == item.IdIngrediente && x.IdDolce == dolce.Id);

                if (item.Quantita == 0 && ingr != null)
                    ingredientiToRemove.Add(ingr);
                else
                {
                    if (ingr == null)
                    {
                        if (item.Quantita > 0)
                            dolce.IngredientiDolces.Add(new IngredientiDolce()
                            {
                                IdDolce = dolce.Id,
                                IdIngrediente = item.IdIngrediente,
                                Quantita = item.Quantita
                            });
                    }
                    else
                        ingr.Quantita = item.Quantita;
                }
            }

            _ctx.IngredientiDolces.RemoveRange(ingredientiToRemove);

            _ctx.SaveChanges();
        }
    }
}
