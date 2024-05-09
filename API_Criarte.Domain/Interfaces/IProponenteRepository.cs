using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IProponenteRepository
    {
        Task<Proponentes> GetProponente(int id_proponente);
        Task<int> CreateProponente(Proponentes proponente);
        Task<int> UpdateProponente(Proponentes proponente);
    }
}
