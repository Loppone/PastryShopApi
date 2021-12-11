using PastryShopApi.BL.Models;
using System.Collections.Generic;

namespace PastryShopApi.BL.Abstract
{
    public interface IVetrina
    {
        List<DolceInVetrina> ListaDolci();
        int AggiungiDolce(DolceInVenditaInsert dolce);
        DolceInVetrina VendiDolce(DolceInVenditaUpdate dolce);
        DolceInVetrina RimuoviDolce(int id);
    }
}
