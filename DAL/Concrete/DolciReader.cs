using PastryShopApi.DAL.Abstract;
using PastryShopApi.ModelPastryShop;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class DolciReader : IDolciReader
    {
        private readonly PastryShopContext _ctx;

        public DolciReader(PastryShopContext ctx)
        {
            _ctx = ctx;
        }

        public Dolce Get(int id)
        {
            return _ctx.Dolces.FirstOrDefault(x => x.Id == id);
        }
    }
}
