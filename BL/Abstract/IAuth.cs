using PastryShopApi.BL.Models;

namespace PastryShopApi.BL.Abstract
{
    public interface IAuth
    {
        Utente Login(string username, string password);
    }
}
