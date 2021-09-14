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
using System;
using StarWarsResistence.Extensions;

namespace StarWarsResistence.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")] 
    [Route("api/v{version:apiVersion}/[controller]")]

    public class RelatoriosController : MainController
    {
        private readonly IRebeldeService _rebeldeService;

        public RelatoriosController(IRebeldeService rebeldeService)
        {
            _rebeldeService = rebeldeService;
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        ///<param name="rebelde">Estrutura do Rebelde a ser adicionado</param>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpGet("percentual/traidores")]
        public int RetornaPercentualTraidores()
        {
            return _rebeldeService.RetornaPercentualTraidores();
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        ///<param name="rebelde">Estrutura do Rebelde a ser adicionado</param>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpGet("percentual/rebelde")]
        public int RetornaPercentualRebeldes()
        {
            return _rebeldeService.RetornaPercentualRebeldes();
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        ///<param name="rebelde">Estrutura do Rebelde a ser adicionado</param>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpGet("media/recursos")]
        public IList<Tuple<TipoItem,int>> RetornaMediaItem()
        {
            return _rebeldeService.RetornaMediaRecurso();
        }

        /// <summary>
        /// Adiciona Rebeldes
        /// </summary>
        ///<param name="rebelde">Estrutura do Rebelde a ser adicionado</param>
        /// <returns>Rebeldes cadastrados</returns>
        [HttpGet("pontos/perdidos")]
        public int RetornaPontosPerdidos()
        {
            return _rebeldeService.RetornaPontosPerdidosPorTraicao();
        }
    }
}
