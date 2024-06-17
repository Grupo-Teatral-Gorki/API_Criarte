using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IGrupoDespesasRepository
    {
        Task<List<GrupoDespesas>> GetGrupoDespesas();
        Task<int> CreateGrupoDespesas(GrupoDespesas grupo);
        Task<int> UpdateGrupoDespesas(GrupoDespesas grupo);
    }
}
