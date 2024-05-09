using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Criarte.Controllers
{
    public class ProponenteController : Controller
    {
        private readonly IProponenteService _proponenteService;

        public ProponenteController(IProponenteService proponenteService)
        {
            _proponenteService = proponenteService;
        }

        [HttpGet]
        [Route("~/api/proponentes/getproponente/{id_proponente}")]
        public async Task<IActionResult> GetProponente(int id_proponente)
        {
            ProponenteDTO result = await _proponenteService.GetProponente(id_proponente);
            if (result == null)
            {
                return NotFound("Não foi possivel encontrar um proponente com este id.");
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("~/api/proponentes/createProponente/")]
        public async Task<IActionResult> CreateProponente([Required][FromBody] CreateProponenteDTO proponente)
        {
            bool result = await _proponenteService.CreateProponente(proponente);
            if (!result)
            {
                return BadRequest("Não foi possivel cadastrar o proponente.");
            }
            return Ok("Proponente cadastrado com sucesso.");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/proponentes/updateProponente/")]
        public async Task<IActionResult> UpdateProponente([Required][FromBody] ProponenteDTO proponente)
        {
            bool result = await _proponenteService.UpdateProponente(proponente);
            if (!result)
            {
                return BadRequest("Não foi possivel atualizar o proponente.");
            }
            return Ok("Proponente atualizado com sucesso.");
        }
    }
}
