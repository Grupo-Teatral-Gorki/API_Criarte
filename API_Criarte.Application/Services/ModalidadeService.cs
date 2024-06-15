using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Services
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly dbContext _dbContext;
        private readonly IModalidadeRepository _modalidadeRepository;
        private readonly IMapper _mapper;

        public ModalidadeService(dbContext dbContext, IModalidadeRepository modalidadeRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _modalidadeRepository = modalidadeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<Modalidades>>> GetModalidades()
        {
            List<Modalidades> modalidades = await _modalidadeRepository.GetModalidades();
            if(modalidades != null )
            {
                return new ApiResponse<List<Modalidades>>(false, "Lista de modalidades.", modalidades);
            }
            return new ApiResponse<List<Modalidades>>(true, "Nenhuma modalidade encontrada.");
        }

        public async Task<ApiResponse<string>> CreateModalidades(ModalidadesDTO modalidade)
        {
            int modalidades = await _modalidadeRepository.CreateModalidade(_mapper.Map<Modalidades>(modalidade));
            if(modalidades > 0)
            {
                return new ApiResponse<string>(false, "Modalidade criada com sucesso.");
            }
            return new ApiResponse<string>(true, "Ocorreu um erro ao Criar a modalidade.");
        }
    }
}
