using Microsoft.EntityFrameworkCore;
using PastryShopApi.DAL.Abstract;
using PastryShopApi.ModelPastryShop;
using System.Collections.Generic;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class RepositoryVetrinaReader : IReader<DolciInVenditum>
    {
        private readonly PastryShopContext _ctx;

        public RepositoryVetrinaReader(PastryShopContext ctx)
        {
            _ctx = ctx;
        }

        public DolciInVenditum Get(int idDolceVetrina)
        {
            return _ctx.DolciInVendita
                .FirstOrDefault(x => x.Id == idDolceVetrina);
        }

        public List<DolciInVenditum> GetAll()
        {
            return Get()
                .Where(x=> x.Scaduto.HasValue && !x.Scaduto.Value)
                .ToList();
        }

        private IQueryable<DolciInVenditum> Get()
        {
            return _ctx.DolciInVendita
                .Include(x => x.IdDolceNavigation);
        }
    }
}
