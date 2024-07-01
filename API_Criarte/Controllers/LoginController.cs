using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Criarte.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("~/api/usuarios/createuser/")]
        public async Task<IActionResult> CreateUser([Required][FromBody]UsuarioDTO usuario)
        {
            if(usuario == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
            ApiResponse<object> result = await _loginService.CreateUser(usuario);
            if(result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/usuarios/authenticate/")]
        public async Task<IActionResult> Login([Required][FromBody]UsuarioLoginDTO usuario)
        {
            IActionResult response = Unauthorized();
            ApiResponse<UsuarioLogadoDTO> user_ = await _loginService.AuthenticateUser(usuario);
            if (!user_.Error)
            {
                var token = _loginService.GenerateToken(user_.Data);
                response = Ok(new { token, user = user_ });
            }
            else
            {
                response = Unauthorized(user_.Message);
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/usuarios/recovery/{email}")]
        public async Task<IActionResult> Recovery(string email)
        {
            if (email == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
            ApiResponse<string> send = await _loginService.RecoveryPass(email);
            if (send.Error)
            {
                return BadRequest(send);
            }
            return Ok(send);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/usuarios/newPass/")]
        public async Task<IActionResult> NewPass([Required] string pass, [Required] string token)
        {
            if (token == null || pass == null)
            {
                return BadRequest("Requisição não aceita por estar em um formato inválido.");
            }
            ApiResponse<string> send = await _loginService.NewPass(pass, token);
            if (send.Error)
            {
                return BadRequest(send);
            }
            return Ok(send);
        }
    }
}
