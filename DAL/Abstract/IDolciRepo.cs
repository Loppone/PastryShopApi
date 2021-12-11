using PastryShopApi.ModelPastryShop;

namespace PastryShopApi.DAL.Abstract
{
    public interface IDolciReader
    {
        Dolce Get(int id);
    }
}
