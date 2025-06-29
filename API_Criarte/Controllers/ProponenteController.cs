﻿using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Models;
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

        [Authorize]
        [HttpGet]
        [Route("~/api/proponentes/getproponente/{id_proponente}")]
        public async Task<IActionResult> GetProponente(int id_proponente)
        {
            if (id_proponente == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
            ProponenteDTO result = await _proponenteService.GetProponente(id_proponente);
            if (result == null)
            {
                return NotFound("Não foi possivel encontrar um proponente com este id.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/proponentes/getProponentesByUser")]
        public async Task<IActionResult> GetProponenteById()
        {
            List<ProponenteDTO> result = await _proponenteService.GetProponenteByIdUsuario();
            if (result.Count <= 0)
            {
                return NotFound("Não foi possivel encontrar proponentes cadastrados por este usuario.");
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("~/api/proponentes/createProponente/")]
        public async Task<IActionResult> CreateProponente([Required][FromBody] CreateProponenteDTO proponente)
        {
            if (proponente == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
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
            if (proponente == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
            bool result = await _proponenteService.UpdateProponente(proponente);
            if (!result)
            {
                return BadRequest("Não foi possivel atualizar o proponente.");
            }
            return Ok("Proponente atualizado com sucesso.");
        }
    }
}
