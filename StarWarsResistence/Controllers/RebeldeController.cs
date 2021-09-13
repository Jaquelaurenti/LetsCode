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
using System.Threading.Tasks;

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
        private readonly IInventarioService _inventarioService;
        private readonly IMapper _mapper;
        private readonly StarWarsContexto _context;

        public RebeldeController(IRebeldeService rebeldeService, IMapper mapper, ILocalizacaoService localizacaoService, IInventarioService inventarioService,
            StarWarsContexto context)
        {
            _rebeldeService = rebeldeService;
            _localizacaoService = localizacaoService;
            _inventarioService = inventarioService;
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        ///<param name="rebelde">Estrutura do Rebelde a ser adicionado</param>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Rebelde>> Post([FromBody] RebeldeDTO rebelde)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saveLocalizacao = await InsereLocalizacaoRebeldde(rebelde.Localizacao);
            var saveInventario = await InsereInventario(rebelde);

            var request = new Rebelde
            {
                Idade = rebelde.Idade,
                Nome = rebelde.Nome,
                IdGenero = (Genero)rebelde.Genero,
                Localizacao = saveLocalizacao,
                IdLocalizacao = saveLocalizacao.Id,
                Reports = 0,
                Traidor = false,
                IdInventario = saveInventario.Id,
                Inventario = saveInventario,
            };
            var response = await _rebeldeService.SaveOrUpdate(request);

            if (response != null)
            {
                return Ok("Rebelde Cadastrado com Sucesso");
            }
            else
            {
                _localizacaoService.Delete(saveLocalizacao);
                _inventarioService.Delete(saveInventario);
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao registrar Rebelde!";
                return NotFound(notfound);
            }
        }

        /// <summary>
        /// Reporta o Rebelde como traidor
        /// </summary>
        /// <param name="id">Id do rebelde a ser reportado</param>
        /// <returns>Rebelde reportado</returns>
        [HttpPut("traidor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Rebelde> ReportaTraidor(int id)
        {
            Rebelde model =  _rebeldeService.FindByIdRebelde(id);
            if(model == null) return NotFound();

            model.Reports = model.Reports + 1;

            // Só inativa os itens do traidor quando o mesmo tiver três ou mais reports 
            if (model.Reports >= 3)
            {
                InsereRebeldeTraidor(model);
            }
            return Ok(model);

        }

        /// <summary>
        /// Atualiza Localizacao do Rebelde
        /// </summary>
        /// <param name="localizacaoNova">Localização modificada</param>
        /// <param name="id">Id do rebelde que terá a localização alterada</param>
        /// <returns>Localizacao</returns>
        [HttpPut("localizacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Rebelde>> AtualizaLocalizacao(int id, LocalizacaoDTO localizacaoNova)
        {
            var localizacao = _localizacaoService.FindByIdRebelde(id);

            if(localizacao == null)
            {
                object res = null;
                NotFoundObjectResult notFound = new NotFoundObjectResult(res);
                notFound.StatusCode = 404;

                notFound.Value = "O Rebelde " + id + " não foi encontrado!";
                return NotFound(notFound);
            }
            else
            {
                localizacao.Galaxia = localizacaoNova.Galaxia;
                localizacao.Latitude = localizacaoNova.Latitude;
                localizacao.Longitude = localizacaoNova.Longitude;
                localizacao.Nome = localizacaoNova.Nome;

                var atualizado = await _localizacaoService.SaveOrUpdate(localizacao);

                return Ok(atualizado);

            }

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

        #region private methods

        private ActionResult<Rebelde> InsereRebeldeTraidor(Rebelde rebelde)
        {
            rebelde.Traidor = true;

            _rebeldeService.SaveOrUpdate(rebelde);

            return Ok(rebelde);

        }

        private async Task<Localizacao> InsereLocalizacaoRebeldde(LocalizacaoDTO value)
        {
            var localizacao = new Localizacao
            {
                Galaxia = value.Galaxia,
                Nome = value.Nome,
                Latitude = value.Latitude,
                Longitude = value.Longitude,

            };

            var saveLocalizacao = await _localizacaoService.SaveOrUpdate(localizacao);

            return saveLocalizacao;
        }

        private async Task<Inventario> InsereInventario(RebeldeDTO value)
        {
            var listInventario = new List<ItemInventario>();

            foreach (var item in value.Inventario.Itens)
            {
                var newItem = new ItemInventario();
                newItem.Tipo = (TipoItem)item.Tipo;
                if (TipoItem.Agua == newItem.Tipo) newItem.Pontuacao = 1;
                if (TipoItem.Arma == newItem.Tipo) newItem.Pontuacao = 4;
                if (TipoItem.Comimda == newItem.Tipo) newItem.Pontuacao = 2;
                if (TipoItem.Municao == newItem.Tipo) newItem.Pontuacao = 3;

                listInventario.Add(newItem);
            }
            var inventario = new Inventario
            {
                Itens = listInventario,
            };

            var saveInventario = await _inventarioService.SaveOrUpdate(inventario);


            return saveInventario;
        }
        #endregion

    }
}
