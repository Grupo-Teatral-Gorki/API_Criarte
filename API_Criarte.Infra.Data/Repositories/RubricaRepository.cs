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
    public class RubricaRepository : IRubricaRepository
    {
        private readonly dbContext _dbContext;

        public RubricaRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Rubrica>> GetRubrica()
        {
            var rubricas = await _dbContext.Rubrica.ToListAsync();
            return rubricas;
        }

        public async Task<int> CreateRubrica(Rubrica rubrica)
        {
            await _dbContext.Rubrica.AddAsync(rubrica);
            var saved_rubrica = _dbContext.SaveChanges();

            return saved_rubrica;
        }

        public async Task<int> UpdateRubrica(Rubrica rubrica)
        {
            _dbContext.Rubrica.Update(rubrica);
            var saved_rubrica = await _dbContext.SaveChangesAsync();

            return saved_rubrica;
        }
    }
}
