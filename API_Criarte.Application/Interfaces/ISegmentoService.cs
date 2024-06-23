using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Application.DTOs;

namespace API_Criarte.Application.Interfaces
{
    public interface ISegmentoService
    {
        Task<ApiResponse<List<Segmento>>> GetSegmentos();
        Task<ApiResponse<string>> CreateEdital(SegmentoDTO segmento);
        Task<ApiResponse<string>> UpdateEdital(Segmento segmento);
    }
}
