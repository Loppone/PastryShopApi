using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class DolciInVenditum
    {
        public int Id { get; set; }
        public int IdDolce { get; set; }
        public int? Disponibilita { get; set; }
        public DateTime? DataMessaInVendita { get; set; }
        public bool? Scaduto { get; set; }

        public virtual Dolce IdDolceNavigation { get; set; }
    }
}
