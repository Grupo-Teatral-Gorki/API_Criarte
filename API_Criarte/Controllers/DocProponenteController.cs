using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Criarte.Controllers
{
    public class DocProponenteController : Controller
    {
        private readonly IDocumentosProponenteService _projetoService;

        public DocProponenteController(IDocumentosProponenteService projetoService)
        {
            _projetoService = projetoService;
        }

        //[Authorize]
        [Route("~/api/docProponente/Create")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse<string>>> PutProponenteDoc([Required][FromForm] ArquivoProjeto arquivo)
        {
            ApiResponse<string> result = await _projetoService.PutDocumentoProponente(arquivo.IdProjeto, arquivo.Archive, arquivo.IdTipo);
            if (result.Error)
            {
                BadRequest(result);
            }

            return Ok(result);
        }

        //[Authorize]
        [Route("~/api/docProponente/Get")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse<string>>> GetProponenteDoc([Required] int id_projeto, [Required] int id_tipo, [Required] int id_documento)
        {
            ApiResponse<string> result = await _projetoService.GetDocumentoProponente(id_projeto, id_tipo, id_documento);
            if (result.Error)
            {
                BadRequest(result);
            }

            return Ok(result);
        }
    }
}
