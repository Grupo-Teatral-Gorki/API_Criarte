using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API_Criarte.Controllers
{
    public class SegmentoController : Controller
    {
        private readonly ISegmentoService _segmentoService;

        public SegmentoController(ISegmentoService segmentoService)
        {
            _segmentoService = segmentoService;
        }

        [HttpGet]
        [Route("~/api/segmento")]
        public async Task<IActionResult> GetSegmentos()
        {
            ApiResponse<List<Segmento>> result = await _segmentoService.GetSegmentos();
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/segmento/createSegmento")]
        public async Task<IActionResult> CreateSegmento([FromBody] SegmentoDTO segmento)
        {
            ApiResponse<string> result = await _segmentoService.CreateEdital(segmento);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost]
        [Route("~/api/segmento/updateSegmento")]
        public async Task<IActionResult> UpdateModalidade([FromBody] Segmento segmento)
        {
            ApiResponse<string> result = await _segmentoService.UpdateEdital(segmento);
            if (result.Error)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
