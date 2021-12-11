using System;

namespace PastryShopApi.BL.Abstract
{
    public  interface ICalcolatorePrezzo
    {
        decimal Calcola(DateTime dataMessaInVendita, decimal prezzoIniziale);
    }
}
