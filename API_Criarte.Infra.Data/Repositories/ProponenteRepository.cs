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
    public class ProponenteRepository : IProponenteRepository
    {
        private readonly dbContext _dbContext;

        public ProponenteRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Proponentes> GetProponente(int id_proponente)
        {
            var proponente = await _dbContext.Proponentes.AsNoTracking().Where(x => x.IdProponente == id_proponente).FirstOrDefaultAsync().ConfigureAwait(false);
            return proponente;
        }

        public async Task<List<Proponentes>> GetProponenteByIdUsuario(int id_usuario)
        {
            var proponente = await _dbContext.Proponentes.AsNoTracking().Where(x => x.IdUsuarioCadastro == id_usuario).ToListAsync().ConfigureAwait(false);
            return proponente;
        }

        public async Task<int> CreateProponente(Proponentes proponente)
        {
            await _dbContext.Proponentes.AddAsync(proponente);
            return _dbContext.SaveChanges();
        }

        public async Task<int> UpdateProponente(Proponentes proponente)
        {
            _dbContext.Proponentes.Update(proponente);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
