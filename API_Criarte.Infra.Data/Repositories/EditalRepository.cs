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
    public class EditalRepository : IEditalRepository
    {
        private readonly dbContext _dbContext;

        public EditalRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Edital>> GetEditais()
        {
            var editais = await _dbContext.Edital.ToListAsync();
            return editais;
        }

        public async Task<int> CreateEdital(Edital edital)
        {
            await _dbContext.Edital.AddAsync(edital);
            var saved_edital = _dbContext.SaveChanges();

            return saved_edital;
        }

        public async Task<int> UpdateEdital(Edital edital)
        {
            _dbContext.Edital.Update(edital);
            var saved_edital = await _dbContext.SaveChangesAsync();

            return saved_edital;
        }
    }
}
