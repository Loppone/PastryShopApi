using System.Collections.Generic;

namespace PastryShopApi.BL.Models
{
    public class Dolce
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }

        public List<Ingrediente> Ingredienti { get; set; }
    }
}