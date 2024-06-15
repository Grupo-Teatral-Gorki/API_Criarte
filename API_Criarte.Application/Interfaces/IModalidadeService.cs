using API_Criarte.Application.DTOs;
using API_Criarte.Domain;
using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IModalidadeService
    {
        Task<ApiResponse<List<Modalidades>>> GetModalidades();
        Task<ApiResponse<string>> CreateModalidades(ModalidadesDTO modalidade);
        Task<ApiResponse<string>> UpdateModalidade(Modalidades modalidade);
    }
}
