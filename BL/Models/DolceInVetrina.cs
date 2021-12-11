using System;

namespace PastryShopApi.BL.Models
{
    public class DolceInVetrina
    {
        public int Id { get; set; }
        public int IdLotto { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public decimal PrezzoScontato { get; set; }

        public int Disponibilita { get; set; }
        public DateTime DataMessaInVendita { get; set; }
    }
}
