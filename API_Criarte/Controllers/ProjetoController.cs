using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Mvc;
using API_Criarte.Application.DTOs;

namespace API_Criarte.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        [Route("~/api/projeto")]
        public async Task<IActionResult> GetProjetos()
        {
            ApiResponse<List<ProjetosDTO>> result = await _projetoService.GetProjetos();
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }
    }
}
