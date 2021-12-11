using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredientiDolces = new HashSet<IngredientiDolce>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Um { get; set; }

        public virtual Um UmNavigation { get; set; }
        public virtual ICollection<IngredientiDolce> IngredientiDolces { get; set; }
    }
}
