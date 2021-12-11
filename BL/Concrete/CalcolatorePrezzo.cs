using PastryShopApi.BL.Abstract;
using System;

namespace PastryShopApi.BL.Concrete
{
    public class CalcolatorePrezzo : ICalcolatorePrezzo
    {
        public CalcolatorePrezzo()
        {

        }

        public decimal Calcola(DateTime dataMessaInVendita, decimal prezzoIniziale)
        {
            // Qui andrebbe invertita la dipendenza e togliere if/switch...
            if (dataMessaInVendita.AddDays(1) >= DateTime.Now)
                return prezzoIniziale;

            if (dataMessaInVendita.AddDays(2) >= DateTime.Now)
                return prezzoIniziale * 80 / 100;

            if (dataMessaInVendita.AddDays(3) >= DateTime.Now)
                return prezzoIniziale * 20 / 100;

            // Zero significa dolce scaduto!!
            return 0;
        }
    }
}
