using PastryShopApi.DAL.Abstract;
using PastryShopApi.ModelPastryShop;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public class RepositoryAuthentication : IRepoAuth
    {
        private readonly PastryShopContext _ctx;

        public RepositoryAuthentication(PastryShopContext ctx)
        {
            _ctx = ctx;
        }

        public Utente GetUtente(string username, string password)
        {
            return _ctx.Utentes.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
