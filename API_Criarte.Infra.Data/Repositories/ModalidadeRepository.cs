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
    public class ModalidadeRepository : IModalidadeRepository
    {
        private readonly dbContext _dbContext;

        public ModalidadeRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Modalidades>> GetModalidades()
        {
            var modalidades = await _dbContext.Modalidades.ToListAsync();
            return modalidades;
        }

        public async Task<int> CreateModalidade(Modalidades modalidade)
        {
            await _dbContext.Modalidades.AddAsync(modalidade);
            var saved_modalidade = _dbContext.SaveChanges();

            return saved_modalidade;
        }

        public async Task<int> UpdateModalidade(Modalidades modalidade)
        {
            _dbContext.Modalidades.Update(modalidade);
            var saved_modalidade = await _dbContext.SaveChangesAsync();

            return saved_modalidade;
        }
    }
}
