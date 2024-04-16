using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
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
            ApiResponse result = await _loginService.CreateUser(usuario);
            if(result.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/usuarios/authenticate/")]
        public async Task<IActionResult> Login([Required][FromBody]UsuarioDTO usuario)
        {
            IActionResult response = Unauthorized();
            var user_ = await _loginService.AuthenticateUser(usuario);
            if (user_ != null)
            {
                var token = _loginService.GenerateToken(user_);
                response = Ok(new { token, user = user_ });
            }
            return response;
        }
    }
}
