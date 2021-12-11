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
    public class IngredientiDolceController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IngredientiDolceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{idDolce:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.Ingrediente>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get(int idDolce)
        {
            var listaIngredientiDolce = DolciUtil.GetElencoIngredientiDolce(idDolce);

            var map = _mapper.Map<List<ModelPastryShop.IngredientiDolce>, List<Models.Api.Ingrediente>>(listaIngredientiDolce);

            return Ok(map);
        }
    }
}
