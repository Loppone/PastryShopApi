using System;
using System.Collections.Generic;

#nullable disable

namespace PastryShopApi.ModelPastryShop
{
    public partial class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
