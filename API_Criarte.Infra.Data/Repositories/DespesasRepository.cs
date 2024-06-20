using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Infra.Data.Repositories
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly dbContext _dbContext;

        public DespesasRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Despesas>> GetDespesas()
        {
            var despesas = await _dbContext.Despesas.ToListAsync();
            return despesas;
        }

        public async Task<List<Despesas>> GetDespesasById(int idProjeto)
        {
            var despesas = await _dbContext.Despesas.AsNoTracking().Where(x => x.IdProjeto.Equals(idProjeto)).ToListAsync();
            return despesas;
        }

        public async Task<Despesas> CreateDespesas(Despesas despesa)
        {
            await _dbContext.Despesas.AddAsync(despesa);
            _dbContext.SaveChanges();

            return despesa;
        }

        public async Task<int> UpdateDespesas(Despesas despesa)
        {
            _dbContext.Despesas.Update(despesa);
            var saved_despesa = await _dbContext.SaveChangesAsync();

            return saved_despesa;
        }
    }
}
