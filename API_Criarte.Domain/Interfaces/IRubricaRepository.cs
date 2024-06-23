using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IRubricaRepository
    {
        Task<List<Rubrica>> GetRubrica();
        Task<int> CreateRubrica(Rubrica rubrica);
        Task<int> UpdateRubrica(Rubrica rubrica);
    }
}
