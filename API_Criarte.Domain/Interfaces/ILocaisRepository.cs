using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface ILocaisRepository
    {
        Task<List<Locais>> GetLocais();
        Task<List<Locais>> GetLocaisById(int idProjeto);
        Task<Locais> CreateLocais(Locais local);
        Task<int> UpdateLocais(Locais local);
    }
}
