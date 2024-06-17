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
    public class FontesFinanciamentoRepository : IFontesFinanciamentoRepository
    {
        private readonly dbContext _dbContext;

        public FontesFinanciamentoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FontesFinanciamento>> GetFontesFinanciamento()
        {
            var fontes = await _dbContext.FontesFinanciamento.ToListAsync();
            return fontes;
        }

        public async Task<int> CreateFontesFinanciamento(FontesFinanciamento fontes)
        {
            await _dbContext.FontesFinanciamento.AddAsync(fontes);
            var saved_fontes = _dbContext.SaveChanges();

            return saved_fontes;
        }

        public async Task<int> UpdateFontesFinanciamento(FontesFinanciamento fontes)
        {
            _dbContext.FontesFinanciamento.Update(fontes);
            var saved_fontes = await _dbContext.SaveChangesAsync();

            return saved_fontes;
        }
    }
}
