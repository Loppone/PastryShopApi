using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDolciController : ControllerBase
    {

        public ListaDolciController()
        {
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Dictionary<int, string>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get()
        {
            var listaDolci = DolceOperations.ListaDolci();

            return Ok(listaDolci);
        }
    }
}
