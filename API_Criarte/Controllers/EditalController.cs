using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API_Criarte.Controllers
{
    public class EditalController : Controller
    {
        private readonly IEditalService _editalService;

        public EditalController(IEditalService editalService)
        {
            _editalService = editalService;
        }

        [HttpGet]
        [Route("~/api/edital")]
        public async Task<IActionResult> GetEditais()
        {
            ApiResponse<List<Edital>> result = await _editalService.GetEditais();
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/edital/createEdital")]
        public async Task<IActionResult> CreateEdital([FromBody] EditalDTO edital)
        {
            ApiResponse<string> result = await _editalService.CreateEdital(edital);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost]
        [Route("~/api/edital/updateEdital")]
        public async Task<IActionResult> UpdateModalidade([FromBody] Edital edital)
        {
            ApiResponse<string> result = await _editalService.UpdateModalidade(edital);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
