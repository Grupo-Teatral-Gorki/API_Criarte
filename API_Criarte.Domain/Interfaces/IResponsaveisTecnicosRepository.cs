using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IResponsaveisTecnicosRepository
    {
        Task<List<ResponsaveisTecnicos>> GetResponsaveisTecnicos();
        Task<List<ResponsaveisTecnicos>> GetResponsaveisTecnicosById(int idProjeto);
        Task<ResponsaveisTecnicos> CreateResponsaveisTecnicos(ResponsaveisTecnicos responsavel);
        Task<int> UpdateResponsaveisTecnicos(ResponsaveisTecnicos responsavel);
    }
}
