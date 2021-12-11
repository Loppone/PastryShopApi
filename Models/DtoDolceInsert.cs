using System.Collections.Generic;

namespace PastryShopApi.Models.Api
{
    public class DtoDolceInsert
    {
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public List<DtoIngredienteUpsert> Ingredienti { get; set; }
    }
}
