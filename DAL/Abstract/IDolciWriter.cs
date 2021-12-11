
namespace PastryShopApi.DAL.Abstract
{
    public interface IDolciWriter
    {
        int Add(BL.Models.DolceInsert payload);
        void Update(BL.Models.DolceUpdate payload);
        ModelPastryShop.Dolce Delete(int id);
    }
}
