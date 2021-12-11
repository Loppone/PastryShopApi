using PastryShopApi.DAL.Models;
using PastryShopApi.ModelPastryShop;

namespace PastryShopApi.DAL.Abstract
{
    public interface IVetrinaDolciWriter
    {
        int Add(DataInsertDolceVetrina dataDolce);
        DolciInVenditum Update(DataUpdateDolceVetrina mapDal);
        DolciInVenditum Delete(int id);
    }
}
