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
    public class FonteFinanciamentoRepository : IFonteFinanciamentoRepository
    {
        private readonly dbContext _dbContext;

        public FonteFinanciamentoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FonteFinanciamento>> GetFonteFinanciamento()
        {
            var fontes = await _dbContext.FonteFinanciamento.ToListAsync();
            return fontes;
        }

        public async Task<int> CreateFonteFinanciamento(FonteFinanciamento fontes)
        {
            await _dbContext.FonteFinanciamento.AddAsync(fontes);
            var saved_fontes = _dbContext.SaveChanges();

            return saved_fontes;
        }

        public async Task<int> UpdateFonteFinanciamento(FonteFinanciamento fontes)
        {
            _dbContext.FonteFinanciamento.Update(fontes);
            var saved_fontes = await _dbContext.SaveChangesAsync();

            return saved_fontes;
        }
    }
}
