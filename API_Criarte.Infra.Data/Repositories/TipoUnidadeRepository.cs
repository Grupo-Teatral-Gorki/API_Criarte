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
    public class TipoUnidadeRepository : ITipoUnidadeRepository
    {
        private readonly dbContext _dbContext;

        public TipoUnidadeRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoUnidade>> GetTipoUnidade()
        {
            var tipos = await _dbContext.TipoUnidade.ToListAsync();
            return tipos;
        }

        public async Task<int> CreateTipoUnidade(TipoUnidade tipo)
        {
            await _dbContext.TipoUnidade.AddAsync(tipo);
            var saved_tipo = _dbContext.SaveChanges();

            return saved_tipo;
        }

        public async Task<int> UpdateTipoUnidade(TipoUnidade tipo)
        {
            _dbContext.TipoUnidade.Update(tipo);
            var saved_tipo = await _dbContext.SaveChangesAsync();

            return saved_tipo;
        }
    }
}
