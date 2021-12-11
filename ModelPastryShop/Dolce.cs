using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class Dolce
    {
        public Dolce()
        {
            DolciInVendita = new HashSet<DolciInVenditum>();
            IngredientiDolces = new HashSet<IngredientiDolce>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }

        public virtual ICollection<DolciInVenditum> DolciInVendita { get; set; }
        public virtual ICollection<IngredientiDolce> IngredientiDolces { get; set; }
    }
}
