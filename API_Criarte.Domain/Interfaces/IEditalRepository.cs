using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IEditalRepository
    {
        Task<List<Edital>> GetEditais();
        Task<int> CreateEdital(Edital edital);
        Task<int> UpdateEdital(Edital edital);
    }
}
