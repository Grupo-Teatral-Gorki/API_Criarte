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
    public class LocaisRepository : ILocaisRepository
    {
        private readonly dbContext _dbContext;

        public LocaisRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Locais>> GetLocais()
        {
            var locais = await _dbContext.Locais.ToListAsync();
            return locais;
        }

        public async Task<int> CreateLocais(Locais local)
        {
            await _dbContext.Locais.AddAsync(local);
            var saved_local = _dbContext.SaveChanges();

            return saved_local;
        }

        public async Task<int> UpdateLocais(Locais local)
        {
            _dbContext.Locais.Update(local);
            var saved_local = await _dbContext.SaveChangesAsync();

            return saved_local;
        }
    }
}
