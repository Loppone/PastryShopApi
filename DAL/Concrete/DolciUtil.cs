using Microsoft.EntityFrameworkCore;
using PastryShopApi.ModelPastryShop;
using System.Collections.Generic;
using System.Linq;

namespace PastryShopApi.DAL.Concrete
{
    public static class DolciUtil
    {
        public static bool NameTaken(string name)
        {
            using (var ctx = new ModelPastryShop.PastryShopContext())
            {
                return ctx.Dolces.Any(x => x.Nome == name);
            }
        }

        public static Dictionary<int, string> GetElencoDolci()
        {
            using (var ctx = new ModelPastryShop.PastryShopContext())
            {
                return ctx.Dolces
                    .OrderBy(x => x.Nome)
                    .ToDictionary(x => x.Id, y => y.Nome);
            }
        }

        public static List<Ingrediente> GetElencoIngredienti()
        {
            using (var ctx = new ModelPastryShop.PastryShopContext())
            {
                return ctx.Ingredientes
                       .Include(x => x.UmNavigation)
                       .ToList();
            }
        }

        public static List<IngredientiDolce> GetElencoIngredientiDolce(int idDolce)
        {
            using (var ctx = new ModelPastryShop.PastryShopContext())
            {
                return ctx.IngredientiDolces
                       .Include(x => x.IdIngredienteNavigation)
                       .ThenInclude(y=>y.UmNavigation)
                       .Include(x=>x.IdDolceNavigation)
                       .Where(x=>x.IdDolce == idDolce)
                       .ToList();
            }
        }
    }
}
