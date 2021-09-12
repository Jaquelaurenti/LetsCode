using AutoMapper;
using StarWarsResistence.DTO;
using StarWarsResistence.Models;
using StarWarsResistence.Services;
using StarWarsResistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsResistence.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")] 
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    public class RebeldeController : ControllerBase
    {
        private readonly IRebeldeService _RebeldeService;
        private readonly IMapper _mapper;
        private readonly CentralErroContexto _context;

        public RebeldeController(IRebeldeService RebeldeService, IMapper mapper, CentralErroContexto context)
        {
            _RebeldeService = RebeldeService;
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Rebelde>> Post([FromBody] RebeldeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = new Rebelde();

            var response = _RebeldeService.SaveOrUpdate(request);
            if (response != null)
            {
                return Ok("Rebelde cadastrado com sucesso!");
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao registrar Rebelde!";
                return NotFound(notfound);
            }
        }

        /// <summary>
        /// Retorna os Rebeldes
        /// </summary>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Rebelde>> Get()
        {
            var Rebelde = _RebeldeService.FindAllRebeldes();
            if (Rebelde != null)
            {
                
                return Ok(Rebelde.Select(x => _mapper.Map<Rebelde>(x)).ToList());
            }
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Rebelde> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Rebelde Rebelde = _RebeldeService.FindByIdRebelde(id);
            
            if(Rebelde != null)
            {
                _context.Rebeldes.Remove(Rebelde);
                var retorno = _RebeldeService.SaveOrUpdate(Rebelde);
                return Ok(retorno);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notFound = new NotFoundObjectResult(res);
                notFound.StatusCode = 404;

                notFound.Value = "O Rebelde " + id +" não foi encontrado!";
                return NotFound(notFound);
            }
        }




    }
}
