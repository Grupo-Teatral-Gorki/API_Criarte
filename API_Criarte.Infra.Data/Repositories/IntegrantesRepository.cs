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
    public class IntegrantesRepository : IIntegrantesRepository
    {
        private readonly dbContext _dbContext;

        public IntegrantesRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Integrantes>> GetIntegrantes()
        {
            var integrantes = await _dbContext.Integrantes.ToListAsync();
            return integrantes;
        }

        public async Task<List<Integrantes>> GetIntegrantesById(int idProjeto)
        {
            var integrantes = await _dbContext.Integrantes.AsNoTracking().Where(x => x.IdProjeto.Equals(idProjeto)).ToListAsync();
            return integrantes;
        }

        public async Task<Integrantes> CreateIntegrantes(Integrantes integrante)
        {
            await _dbContext.Integrantes.AddAsync(integrante);
            _dbContext.SaveChanges();

            return integrante;
        }

        public async Task<int> UpdateIntegrantes(Integrantes integrante)
        {
            _dbContext.Integrantes.Update(integrante);
            var saved_integrante = await _dbContext.SaveChangesAsync();

            return saved_integrante;
        }
    }
}
