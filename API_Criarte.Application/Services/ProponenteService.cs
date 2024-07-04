using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Lib;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Services
{
    public class ProponenteService : IProponenteService
    {
        private readonly IProponenteRepository _repository;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor user;
        private int id_usuario;

        public ProponenteService(IProponenteRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            user = accessor;

            id_usuario = Convert.ToInt32(AlterClaim.GetClaimValue(this.user.HttpContext.User, "id_usuario"));
        }

        public async Task<ProponenteDTO> GetProponente(int id_proponente)
        {
            var proponente = _mapper.Map<ProponenteDTO>( await _repository.GetProponente(id_proponente));
            return proponente;
        }

        public async Task<List<ProponenteDTO>> GetProponenteByIdUsuario()
        {
            var proponente = _mapper.Map<List<ProponenteDTO>>( await _repository.GetProponenteByIdUsuario(id_usuario));
            return proponente;
        }

        public async Task<bool> CreateProponente(CreateProponenteDTO proponente)
        {
            var prop = _mapper.Map<Proponentes>(proponente);
            prop.IdUsuarioCadastro = id_usuario;

            var result = await _repository.CreateProponente(prop);

            if(result <= 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateProponente(ProponenteDTO proponente)
        {
            var prop = _mapper.Map<Proponentes>(proponente);
            var result = await _repository.UpdateProponente(prop);

            if(result <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
