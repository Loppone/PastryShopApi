using System.Collections.Generic;

namespace PastryShopApi.DAL.Abstract
{
    public interface IReader<T>
    {
        List<T> GetAll();
        T Get(int id);
    }
}
