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
using System.Net.Mail;
using System.Text.RegularExpressions;
using API_Lib;

namespace API_Criarte.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly dbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILoginRepository _repository;
        private readonly ISendMailGateway _gateway;

        public LoginService(dbContext dbContext, IMapper mapper, IConfiguration configuration, ILoginRepository repository, ISendMailGateway gateway)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = configuration;
            _repository = repository;
            _gateway = gateway;
        }

        public async Task<ApiResponse<object>> CreateUser(UsuarioDTO usuario)
        {
            ApiResponse<object> response = new ApiResponse<object>(true, "Erro ao criar login.");

            if (ValidateUserAndPass(usuario, out response))
            {
                return response;
            }

            usuario.Senha = GerarHashMd5(usuario.Senha);
            var user = _mapper.Map<Usuarios>(usuario);

            response = await _repository.CreateUser(user);

            return response;
        }

        public async Task<ApiResponse<UsuarioLogadoDTO>> AuthenticateUser(UsuarioLoginDTO loginDto)
        {
            var login = _mapper.Map<UsuarioDTO>(loginDto);
            ApiResponse<UsuarioLogadoDTO> response = new ApiResponse<UsuarioLogadoDTO>(true, "Email e/ou senha inválido.");
            var user = _mapper.Map<Usuarios>(login);

            user.Senha = GerarHashMd5(login.Senha);

            var usuario = await _repository.GetUser(user);

            if(usuario == null)
            {
                return response;
            }
            else
            {
                UsuarioLogadoDTO logged = new UsuarioLogadoDTO
                {
                    Id = usuario.IdUsuario,
                    Usuario = usuario.Usuario,
                    TipoUsuario = usuario.TipoUsuario
                };
                response = new ApiResponse<UsuarioLogadoDTO>( false, "Login realizado com sucesso.", logged );
            }

            
            return response;
        }

        public async Task<ApiResponse<string>> RecoveryPass(string email)
        {
            ApiResponse<string> response = new ApiResponse<string>(true, "Ocorreu um erro ao recuperar senha.");
            if (Util.ValidEmail(email))
            {
                if (await _repository.VerifyExistingUser(email))
                {
                    ApiResponse<string> sended = _gateway.SendRecoveryMail(email);
                    if (!sended.Error)
                    {
                        if(await _repository.SaveToken(email, sended.Data) == 1)
                        {
                            response = new ApiResponse<string>(false, "Email de recuperação enviado.");
                        }
                        else
                        {
                            response = new ApiResponse<string>(true, "Ocorreu um erro ao gravar o Token.");
                        }
                    }
                    else
                    {
                        response = new ApiResponse<string>(true, "Erro ao enviar email.", sended.Message);
                    }
                }
                else
                {
                    response = new ApiResponse<string>(true, "Usuário não encontrado.");
                }
            }
            else
            {
                response = new ApiResponse<string>(true, "Email não é válido.");
            }
            return response;
        }

        public async Task<ApiResponse<string>> NewPass(string pass, string token)
        {
            if(Util.ValidPass(pass))
            {
                string hash = GerarHashMd5(pass);
                Usuarios user =  await _repository.GetUserByToken(token);

                if(user == null)
                {
                    return new ApiResponse<string>(true, "Token não encontrado.");
                }
                int min = Convert.ToInt32((DateTime.Now - user.ExpirationToken).Value.TotalMinutes);

                if (min > 30)
                {
                    return new ApiResponse<string>(true, "Token expirado.");
                }

                user.Senha = hash;
                user.Token = null;
                user.ExpirationToken = null;
                int updated = await _repository.UpdateUser(user);
                if(updated > 0)
                {
                    return new ApiResponse<string>(false, "Nova senha registrada.");
                }
                else
                {
                    return new ApiResponse<string>(true, "Erro ao registrar nova senha.");
                }
            }
            else
            {
                return new ApiResponse<string>(true, "Senha inválida.");
            }
        }

        #region Funções Auxiliares
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

        private bool ValidateUserAndPass(UsuarioDTO user, out ApiResponse<object> response)
        {
            bool email = Util.ValidEmail(user.Usuario);
            bool pass = Util.ValidPass(user.Senha);
            bool result = false;
            response = new ApiResponse<object>(true, "Erro ao criar login.");

            if (user.TipoUsuario < 1 || user.TipoUsuario > 4)
            {
                response = new ApiResponse<object>(true, "Tipo de usuario inválido.");
                result = true;
                return result;
            }

            if (email && pass)
            {
                response = new ApiResponse<object>(false, "Usuario e senha válidos.");
                result = false;
            }
            else if(!email)
            {
                response = new ApiResponse<object>(true, "Usuário inválido.");
                result = true;
            }
            else if(!pass)
            {
                response = new ApiResponse<object>(true, "Senha inválida.");
                result = true;
            }
            return result;
        }


        #endregion
    }
}
