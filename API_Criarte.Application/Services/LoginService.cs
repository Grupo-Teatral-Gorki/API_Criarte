using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Infra.Data.Context;
using API_Criarte.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using API_Criarte.Application.DTOs;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace API_Criarte.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly dbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILoginRepository _repository;

        public LoginService(dbContext dbContext, IMapper mapper, IConfiguration configuration, ILoginRepository repository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = configuration;
            _repository = repository;
        }

        public async Task<ApiResponse> CreateUser(UsuarioDTO usuario)
        {
            usuario.Senha = GerarHashMd5(usuario.Senha);
            var user = _mapper.Map<Usuarios>(usuario);
            return await _repository.CreateUser(user);
        }

        public async Task<UsuarioLogadoDTO> AuthenticateUser(UsuarioDTO login)
        {
            var user = _mapper.Map<Usuarios>(login);
            user.Senha = GerarHashMd5(login.Senha);

            var usuario = await _repository.GetUser(user);

            UsuarioLogadoDTO logged = new UsuarioLogadoDTO
            {
                Id = usuario.IdUsuario,
                Usuario = usuario.Usuario
            };

            return logged;
        }

        private static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public string GenerateToken(UsuarioLogadoDTO login)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claimsdata = new[] {
                    new Claim("id_usuario", Convert.ToString(login.Id))
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claimsdata,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
