using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.BL.Abstract;
using PastryShopApi.Models.Api;
using System.Net;

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuth _authentication;

        public LoginController(IAuth authentication)
        {
            _authentication = authentication;
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Utente non trovato")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Post([FromBody] LoginUtente utente)
        {
            // Chiamata al layer di Business Logic
            var user = _authentication.Login(utente.Username, utente.Password);

            if (user == null)
                return StatusCode(400, "Utente non trovato");

            return Ok(user);
        }
    }
}
