using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IIntegrantesRepository
    {
        Task<List<Integrantes>> GetIntegrantes();
        Task<List<Integrantes>> GetIntegrantesById(int idProjeto);
        Task<Integrantes> CreateIntegrantes(Integrantes integrante);
        Task<int> UpdateIntegrantes(Integrantes integrante);
    }
}
