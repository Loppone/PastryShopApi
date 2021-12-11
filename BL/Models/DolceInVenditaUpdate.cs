// Stessa classe delle Api, ma così separiamo i dto dalle classi di business
// Per differenziare dalle Api qui non utilizzo l'ereditarietà (solo allo scopo di mostrare le differenze che ci possono essere tra i vari layer)

namespace PastryShopApi.BL.Models
{
    public class DolceInVenditaUpdate
    {
        public int IdDolceVetrina { get; set; }
        public int NumeroDolciDaVendere { get; set; }
    }
}
