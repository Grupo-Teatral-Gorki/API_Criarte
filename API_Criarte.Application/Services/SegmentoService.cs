using API_Criarte.Application.DTOs;
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
using API_Criarte.Application.Interfaces;

namespace API_Criarte.Application.Services
{
    public class SegmentoService: ISegmentoService
    {
        private readonly dbContext _dbContext;
        private readonly ISegmentoRepository _segmentoRepository;
        private readonly IMapper _mapper;

        public SegmentoService(dbContext dbContext, ISegmentoRepository segmentoRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _segmentoRepository = segmentoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<Segmento>>> GetSegmentos()
        {
            List<Segmento> segmento = await _segmentoRepository.GetSegmentos();
            if (segmento != null)
            {
                return new ApiResponse<List<Segmento>>(false, "Lista de Segmentos.", segmento);
            }
            return new ApiResponse<List<Segmento>>(true, "Nenhum segmento encontrado.");
        }

        public async Task<ApiResponse<string>> CreateEdital(SegmentoDTO segmento)
        {
            int result = await _segmentoRepository.CreateSegmento(_mapper.Map<Segmento>(segmento));
            if (result > 0)
            {
                return new ApiResponse<string>(false, "Segmento criado com sucesso.");
            }
            return new ApiResponse<string>(true, "Ocorreu um erro ao criar o segmento.");
        }

        public async Task<ApiResponse<string>> UpdateEdital(Segmento segmento)
        {
            int result = await _segmentoRepository.UpdateEdital(segmento);
            if (result > 0)
            {
                return new ApiResponse<string>(false, "Segmento atualizado com sucesso.");
            }
            return new ApiResponse<string>(true, "Ocorreu um erro ao atualizar o segmento.");
        }
    }
}
