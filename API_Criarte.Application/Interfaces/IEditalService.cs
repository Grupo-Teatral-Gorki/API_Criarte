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
    public interface IEditalService
    {
        Task<ApiResponse<List<Edital>>> GetEditais();
        Task<ApiResponse<string>> CreateEdital(EditalDTO modalidade);
        Task<ApiResponse<string>> UpdateModalidade(Edital modalidade);
    }
}
