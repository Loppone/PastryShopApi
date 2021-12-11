using Microsoft.EntityFrameworkCore;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.ModelPastryShop;
using System.Collections.Generic;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class RepositoryDolceReader : IReader<Dolce>
    {
        private readonly PastryShopContext _ctx;

        public RepositoryDolceReader(PastryShopContext ctx)
        {
            _ctx = ctx;
        }

        public Dolce Get(int id)
        {
            return Get()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Dolce> GetAll()
        {
            return Get()
                .ToList();
        }

        private IQueryable<Dolce> Get()
        {
            return _ctx.Dolces
                .Include(x => x.IngredientiDolces)
                .ThenInclude(y => y.IdIngredienteNavigation)
                .ThenInclude(z => z.UmNavigation);
        }
    }
}
