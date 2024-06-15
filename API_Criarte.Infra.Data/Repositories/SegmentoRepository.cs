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
    public class SegmentoRepository : ISegmentoRepository
    {
        private readonly dbContext _dbContext;

        public SegmentoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Segmento>> GetSegmentos()
        {
            var segmentos = await _dbContext.Segmento.ToListAsync();
            return segmentos;
        }

        public async Task<int> CreateSegmento(Segmento segmento)
        {
            await _dbContext.Segmento.AddAsync(segmento);
            var saved_segmento = _dbContext.SaveChanges();

            return saved_segmento;
        }

        public async Task<int> UpdateEdital(Segmento segmento)
        {
            _dbContext.Segmento.Update(segmento);
            var saved_segmento = await _dbContext.SaveChangesAsync();

            return saved_segmento;
        }
    }
}
