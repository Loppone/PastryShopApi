using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.ModelPastryShop;
using PastryShopApi.Models.Api;
using System;
using System.Linq;
using System.Net;


// Questo Controller simula un job che viene schedulato ogni minuto e che si occupa di eliminare dalla vetrina
// tutti i dolci scaduti.
// Per semplicità di visione ed esecuzione di questo test allo start del client verrà chiamata questa Api
// Può ovviamente essere chiamata a piacere con Swagger.
// Sempre per semplicità non inverto le dipendenze e scrivo tutto il codice qua sotto.

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly PastryShopContext _ctx;

        public JobController(PastryShopContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Utente non trovato")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Post()
        {
            var dolciScaduti = _ctx.DolciInVendita
                .Where(x=> !x.Scaduto.Value)
                .Where(x => 
                (
                    (x.DataMessaInVendita.Value.AddDays(+3) < DateTime.Now) || !x.DataMessaInVendita.HasValue) ||
                    x.Disponibilita <= 0
                );

            // Eseguo una cancellazione logica del dolce in quanto, non avendo un log, ne tengo traccia
            foreach (var item in dolciScaduti)
            {
                item.Scaduto = true;
            }

            _ctx.SaveChanges();

            return Ok();
        }
    }
}
