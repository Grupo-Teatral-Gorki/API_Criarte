using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Infra.Data.Context;

namespace API_Criarte.Application.Services
{
    public class EditalService : IEditalService
    {
        private readonly dbContext _dbContext;
        private readonly IEditalRepository _editalRepository;
        private readonly IMapper _mapper;

        public EditalService(dbContext dbContext, IEditalRepository editalRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _editalRepository = editalRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<Edital>>> GetEditais()
        {
            List<Edital> edital = await _editalRepository.GetEditais();
            if (edital != null)
            {
                return new ApiResponse<List<Edital>>(false, "Lista de Editais.", edital);
            }
            return new ApiResponse<List<Edital>>(true, "Nenhum edital encontrado.");
        }

        public async Task<ApiResponse<string>> CreateEdital(EditalDTO modalidade)
        {
            int edital = await _editalRepository.CreateEdital(_mapper.Map<Edital>(modalidade));
            if (edital > 0)
            {
                return new ApiResponse<string>(false, "Edital criado com sucesso.");
            }
            return new ApiResponse<string>(true, "Ocorreu um erro ao Criar o edital.");
        }

        public async Task<ApiResponse<string>> UpdateModalidade(Edital modalidade)
        {
            int edital = await _editalRepository.UpdateEdital(modalidade);
            if (edital > 0)
            {
                return new ApiResponse<string>(false, "Edital atualizado com sucesso.");
            }
            return new ApiResponse<string>(true, "Ocorreu um erro ao atualizar o edital.");
        }
    }
}
