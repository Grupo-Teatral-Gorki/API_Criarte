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
    public class GrupoDespesasRepository : IGrupoDespesasRepository
    {
        private readonly dbContext _dbContext;

        public GrupoDespesasRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GrupoDespesas>> GetGrupoDespesas()
        {
            var grupo = await _dbContext.GrupoDespesas.ToListAsync();
            return grupo;
        }

        public async Task<int> CreateGrupoDespesas(GrupoDespesas grupo)
        {
            await _dbContext.GrupoDespesas.AddAsync(grupo);
            var saved_grupo = _dbContext.SaveChanges();

            return saved_grupo;
        }

        public async Task<int> UpdateGrupoDespesas(GrupoDespesas grupo)
        {
            _dbContext.GrupoDespesas.Update(grupo);
            var saved_grupo = await _dbContext.SaveChangesAsync();

            return saved_grupo;
        }
    }
}
