using PastryShopApi.BL.Models;
using System.Collections.Generic;

namespace PastryShopApi.BL.Abstract
{
    public interface IDolce
    {
        List<Dolce> Get();
        Dolce Get(int id);
        int Crea(DolceInsert payload);
        void Modifica(DolceUpdate payload);
        Dolce Elimina(int id);
    }
}