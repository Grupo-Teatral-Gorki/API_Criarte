using API_Criarte.Application.DTOs;
using API_Criarte.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<ApiResponse<List<ProjetosDTO>>> GetProjetos();
    }
}
