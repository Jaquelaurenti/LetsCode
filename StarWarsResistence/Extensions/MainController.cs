using System;
using Microsoft.AspNetCore.Mvc;

namespace StarWarsResistence.Extensions
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(bool operacaoValida, object result = null)
        {
            if (operacaoValida)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = "Erro ao executar a operação"
            });
        }
    }
}
