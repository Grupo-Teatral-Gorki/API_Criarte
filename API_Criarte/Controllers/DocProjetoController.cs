using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using API_Criarte.Models;

namespace API_Criarte.Controllers
{
    public class DocProjetoController : Controller
    {
        private readonly IDocumentosProjetoService _projetoService;

        public DocProjetoController(IDocumentosProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        //[Authorize]
        [Route("~/api/docProjeto/Create")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse<string>>> PutProjectDoc([Required][FromForm] ArquivoProjeto arquivo)
        {
            ApiResponse<string> result = await _projetoService.PutDocumentoProjeto(arquivo.IdProjeto, arquivo.Archive, arquivo.IdTipo);
            if (result.Error)
            {
                BadRequest(result);
            }

            return Ok(result);
        }
    }
}
