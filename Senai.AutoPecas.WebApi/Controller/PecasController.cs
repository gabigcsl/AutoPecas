using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {

        PecasRepository PecasRepository = new PecasRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            int IdFornecedor = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "IdFornecedor").Value);
            return Ok(PecasRepository.Listar(IdFornecedor));
        }
    }
}
