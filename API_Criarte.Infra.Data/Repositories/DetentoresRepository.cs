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
    public class DetentoresRepository : IDetentoresRepository
    {
        private readonly dbContext _dbContext;

        public DetentoresRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Detentores>> GetDetentores()
        {
            var detentores = await _dbContext.Detentores.ToListAsync();
            return detentores;
        }

        public async Task<int> CreateDetentores(Detentores detentor)
        {
            await _dbContext.Detentores.AddAsync(detentor);
            var saved_detentor = _dbContext.SaveChanges();

            return saved_detentor;
        }

        public async Task<int> UpdateDetentores(Detentores detentor)
        {
            _dbContext.Detentores.Update(detentor);
            var saved_detentor = await _dbContext.SaveChangesAsync();

            return saved_detentor;
        }
    }
}
