using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.BL.Concrete;
using PastryShopApi.DAL.Concrete;
using System.Collections.Generic;
using System.Net;

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientiController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IngredientiController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.Ingrediente>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get()
        {
            var listaDolci = DolciUtil.GetElencoIngredienti();

            var map = _mapper.Map<List<ModelPastryShop.Ingrediente>, List<Models.Api.Ingrediente>>(listaDolci);

            return Ok(map);
        }
    }
}
