using PastryShopApi.ModelPastryShop;

namespace PastryShopApi.DAL.Abstract
{
    public interface IRepoAuth
    {
        Utente GetUtente(string username, string password);
    }
}
