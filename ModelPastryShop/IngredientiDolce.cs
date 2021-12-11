using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class IngredientiDolce
    {
        public int Id { get; set; }
        public int IdDolce { get; set; }
        public int IdIngrediente { get; set; }
        public decimal? Quantita { get; set; }

        public virtual Dolce IdDolceNavigation { get; set; }
        public virtual Ingrediente IdIngredienteNavigation { get; set; }
    }
}
