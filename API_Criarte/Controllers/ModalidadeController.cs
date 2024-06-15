using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Criarte.Controllers
{
    public class ModalidadeController : Controller
    {
        private readonly IModalidadeService _modalidadeService;

        public ModalidadeController(IModalidadeService modalidadeService)
        {
            _modalidadeService = modalidadeService;
        }

        [HttpGet]
        [Route("~/api/modalidades")]
        public async Task<IActionResult> GetModalidades()
        {
            ApiResponse<List<Modalidades>> result = await _modalidadeService.GetModalidades();
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/modalidades/createModalidade")]
        public async Task<IActionResult> CreateModalidades([FromBody]ModalidadesDTO modalidade)
        {
            ApiResponse<string> result = await _modalidadeService.CreateModalidades(modalidade);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost]
        [Route("~/api/modalidades/updateModalidade")]
        public async Task<IActionResult> UpdateModalidade([FromBody]Modalidades modalidade)
        {
            ApiResponse<string> result = await _modalidadeService.UpdateModalidade(modalidade);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
