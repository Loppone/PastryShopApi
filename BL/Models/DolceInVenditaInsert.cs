// Stessa classe delle Api, ma così separiamo i dto dalle classi di business
// Per differenziare dalle Api qui non utilizzo l'ereditarietà (solo allo scopo di mostrare le differenze che ci possono essere tra i vari layer)

namespace PastryShopApi.BL.Models
{
    public class DolceInVenditaInsert
    {
        public int IdDolce { get; set; }
        public int Disponibilita { get; set; }
    }
}
