namespace PastryShopApi.Models.Api
{
    public class DolceInVetrina
    {
        public int IdLotto { get; set; }
        public string Nome { get; set; }
        public int Disponibilita { get; set; }
        public decimal Prezzo { get; set; }
        public decimal PrezzoScontato { get; set; }

        // Per prevenire i molti problemi di date nel passaggio tra client e server utilizzo il formato Epoch time 
        public long DataMessaInVendita { get; set; }
    }
}
