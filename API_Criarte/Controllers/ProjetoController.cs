using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Mvc;
using API_Criarte.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace API_Criarte.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/listaProjetos")]
        public async Task<IActionResult> GetProjetos()
        {
            ApiResponse<List<ProjetosDTO>> result = await _projetoService.GetProjetos();
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Projeto/{idProjeto}")]
        public async Task<IActionResult> GetProjeto(int idProjeto)
        {
            ApiResponse<ProjetoCompletoDTO> result = await _projetoService.GetProjetoById(idProjeto);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createProjeto/")]
        public async Task<IActionResult> createProjeto([Required]int idEdital, [Required] int idModalidade)
        {
            ApiResponse<ProjetoCompletoDTO> result = await _projetoService.CreateProjeto(idEdital, idModalidade);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("~/api/projeto/updateProjeto/")]
        public async Task<IActionResult> updateProjeto([FromBody]Projeto projeto)
        {
            ApiResponse<int> result = await _projetoService.UpdateProjeto(projeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/fontesFinanceiras/{idProjeto}")]
        public async Task<IActionResult> GetFontesFinanceiras(int idProjeto)
        {
            ApiResponse<List<FontesFinanciamento>> result = await _projetoService.GetFontesFinanceiras(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createFontesFinanceiras")]
        public async Task<IActionResult> CreateFontesFinanceiras([FromBody]FontesFinanciamentoDTO fonteDTO)
        {
            ApiResponse<FontesFinanciamento> result = await _projetoService.CreateFontesFinanceiras(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Despesas/{idProjeto}")]
        public async Task<IActionResult> GetDespesas(int idProjeto)
        {
            ApiResponse<List<Despesas>> result = await _projetoService.GetDespesas(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createDespesas")]
        public async Task<IActionResult> CreateDespesas([FromBody] DespesasDTO fonteDTO)
        {
            ApiResponse<Despesas> result = await _projetoService.CreateDespesas(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Responsaveis/{idProjeto}")]
        public async Task<IActionResult> GetResponsaveis(int idProjeto)
        {
            ApiResponse<List<ResponsaveisTecnicos>> result = await _projetoService.GetResponsaveisTecnicos(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createResponsaveis")]
        public async Task<IActionResult> CreateResponsaveis([FromBody] ResponsaveisTecnicosDTO fonteDTO)
        {
            ApiResponse<ResponsaveisTecnicos> result = await _projetoService.CreateResponsaveisTecnicos(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Locais/{idProjeto}")]
        public async Task<IActionResult> GetLocais(int idProjeto)
        {
            ApiResponse<List<Locais>> result = await _projetoService.GetLocais(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createLocais")]
        public async Task<IActionResult> CreateLocais([FromBody] LocaisDTO fonteDTO)
        {
            ApiResponse<Locais> result = await _projetoService.CreateLocais(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Integrantes/{idProjeto}")]
        public async Task<IActionResult> GetIntegrantes(int idProjeto)
        {
            ApiResponse<List<Integrantes>> result = await _projetoService.GetIntegrantes(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createIntegrantes")]
        public async Task<IActionResult> CreateIntegrantes([FromBody] IntegrantesDTO fonteDTO)
        {
            ApiResponse<Integrantes> result = await _projetoService.CreateIntegrantes(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/projeto/Detentores/{idProjeto}")]
        public async Task<IActionResult> GetDetentores(int idProjeto)
        {
            ApiResponse<List<Detentores>> result = await _projetoService.GetDetentores(idProjeto);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("~/api/projeto/createDetentores")]
        public async Task<IActionResult> CreateDetentores([FromBody] DetentoresDTO fonteDTO)
        {
            ApiResponse<Detentores> result = await _projetoService.CreateDetentores(fonteDTO);
            if (result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
