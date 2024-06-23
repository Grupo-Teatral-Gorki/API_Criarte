using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IDespesasRepository
    {
        Task<List<Despesas>> GetDespesas();
        Task<Despesas> CreateDespesas(Despesas despesa);
        Task<int> UpdateDespesas(Despesas despesa);
        Task<List<Despesas>> GetDespesasById(int idProjeto);
    }
}
