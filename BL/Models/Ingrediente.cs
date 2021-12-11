namespace PastryShopApi.BL.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UM UnitaDiMisura { get; set; }
        public decimal Quantita { get; set; }
    }
}