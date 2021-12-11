using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.BL.Abstract;
using PastryShopApi.BL.Models;
using PastryShopApi.Exceptions;
using PastryShopApi.Models.Api;
using System.Collections.Generic;
using System.Net;

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetrinaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVetrina _ops;

        public VetrinaController(IMapper mapper, IVetrina ops)
        {
            _mapper = mapper;
            _ops = ops;
        }

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.DolceInVetrina>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Dolci non trovati")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get()
        {
            var dolci = _ops.ListaDolci();

            var map = _mapper.Map<List<BL.Models.DolceInVetrina>, List<Models.Api.DolceInVetrina>>(dolci);

            return Ok(map);
        }


        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Post([FromBody] DtoInsertDolceInVetrina payload)
        {
            if (payload.NumeroDolciDaVendere <= 0)
                return StatusCode(400, "La quantità deve essere maggiore di zero!");

            var map = _mapper.Map<DtoInsertDolceInVetrina, DolceInVenditaInsert>(payload);

            try
            {
                var newIdDolce = _ops.AggiungiDolce(map);
                return Ok(newIdDolce);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(400, $"{ex.Message} Id: {ex.IdEntity}");
            }
            catch (System.Exception ex0)
            {
                return StatusCode(500, ex0.Message);
            }
        }


        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Models.Api.DolceInVetrina), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Put([FromBody] DtoUpdateDolce payload)
        {
            var map = _mapper.Map<DtoUpdateDolce, DolceInVenditaUpdate>(payload);

            try
            {
                var updatedDolce = _ops.VendiDolce(map);
                var retDolce = _mapper.Map<BL.Models.DolceInVetrina, Models.Api.DolceInVetrina>(updatedDolce);

                return Ok(retDolce);
            }
            catch (EntityNotFoundException exENF)
            {
                return StatusCode(400, $"{exENF.Message} Id: {exENF.IdEntity}");
            }
            catch (UnderZeroException exUZ)
            {
                return StatusCode(400, exUZ.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Models.Api.DolceInVetrina), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dolce = _ops.RimuoviDolce(id);
                var map = _mapper.Map<BL.Models.DolceInVetrina, Models.Api.DolceInVetrina>(dolce);

                return Ok(map);
            }
            catch (EntityNotFoundException exENF)
            {
                return StatusCode(400, $"{exENF.Message} Id: {exENF.IdEntity}");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
