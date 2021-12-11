using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PastryShopApi.BL.Abstract;
using PastryShopApi.Exceptions;
using PastryShopApi.Models.Api;
using System;
using System.Collections.Generic;
using System.Net;

namespace PastryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDolce _dolce;

        public DolceController(IMapper mapper, IDolce dolce)
        {
            _mapper = mapper;
            _dolce = dolce;
        }


        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.Dolce>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Dolci non trovati")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get()
        {
            var ret = _dolce.Get();

            var map = _mapper.Map<List<BL.Models.Dolce>, List<Models.Api.Dolce>>(ret);
            return Ok(map);
        }


        [HttpGet("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.DolceInVetrina>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "Dolce non trovato")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Get(int id)
        {
            var ret = _dolce.Get(id);

            var map = _mapper.Map<BL.Models.Dolce, Models.Api.Dolce>(ret);
            return Ok(map);
        }


        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Post([FromBody] DtoDolceInsert dolce)
        {
            try
            {
                var r = _dolce.Crea(_mapper.Map<DtoDolceInsert, PastryShopApi.BL.Models.DolceInsert>(dolce));
                return Ok(r);
            }
            catch (AlreadyExistsException)
            {
                return StatusCode(400, "Dolce già inserito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Put(int id, [FromBody] DtoDolceUpdate dolce)
        {
            try
            {
                _dolce.Modifica(_mapper.Map<DtoDolceUpdate, PastryShopApi.BL.Models.DolceUpdate>(dolce));
                return Ok();
            }
            catch (AlreadyExistsException)
            {
                return StatusCode(400, "Dolce già inserito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<Models.Api.DolceInVetrina>), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(string), Description = "")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal Server Error")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dolce = _dolce.Elimina(id);
                var map = _mapper.Map<BL.Models.Dolce, Models.Api.Dolce>(dolce);

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
