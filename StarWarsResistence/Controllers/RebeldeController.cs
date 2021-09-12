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

    public class RebeldeController : ControllerBase
    {
        private readonly IRebeldeService _rebeldeService;
        private readonly ILocalizacaoService _localizacaoService;
        private readonly IMapper _mapper;
        private readonly StarWarsContexto _context;

        public RebeldeController(IRebeldeService rebeldeService, IMapper mapper, ILocalizacaoService localizacaoService,
            StarWarsContexto context)
        {
            _rebeldeService = rebeldeService;
            _localizacaoService = localizacaoService;
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

            var localizacao = new Localizacao
            {
                Galaxia = value.Localizacao.Galaxia,
                Nome = value.Localizacao.Nome,
                Latitude = value.Localizacao.Latitude,
                Longitude = value.Localizacao.Longitude,
     
            };

            var saveLocalizacao = _localizacaoService.SaveOrUpdate(localizacao);


            var request = new Rebelde
            {
                Idade = value.Idade,
                Nome = value.Nome,
                IdGenero = (int)value.Genero,
                Localizacao = saveLocalizacao,
                IdLocalizacao = saveLocalizacao.Id,
            };
            var response = _rebeldeService.SaveOrUpdate(request);

            if (response != null)
            {
                return Ok(response);
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
            var rebelde = _rebeldeService.FindAllRebeldes();
            if (rebelde != null)
            {
                
                return Ok(rebelde.Select(x => _mapper.Map<Rebelde>(x)).ToList());
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
            Rebelde Rebelde = _rebeldeService.FindByIdRebelde(id);
            
            if(Rebelde != null)
            {
                _context.Rebeldes.Remove(Rebelde);
                var retorno = _rebeldeService.SaveOrUpdate(Rebelde);
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
