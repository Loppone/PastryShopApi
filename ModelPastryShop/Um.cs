using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class Um
    {
        public Um()
        {
            Ingredientes = new HashSet<Ingrediente>();
        }

        public int Id { get; set; }
        public string Sigla { get; set; }
        public string NomeCompleto { get; set; }

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
