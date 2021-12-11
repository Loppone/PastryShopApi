using System.Collections.Generic;

namespace PastryShopApi.BL.Models
{
    public class DolceInsert
    {
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public List<IngredienteUpsert> Ingredienti { get; set; }
    }
}
