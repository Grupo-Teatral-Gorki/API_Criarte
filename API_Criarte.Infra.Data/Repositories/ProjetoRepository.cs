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
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly dbContext _dbContext;

        public ProjetoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Projeto>> GetProjeto()
        {
            var projeto = await _dbContext.Projeto.ToListAsync();
            return projeto;
        }

        public async Task<int> CreateProjeto(Projeto projeto)
        {
            await _dbContext.Projeto.AddAsync(projeto);
            var saved_projeto = _dbContext.SaveChanges();

            return saved_projeto;
        }

        public async Task<int> UpdateProjeto(Projeto projeto)
        {
            _dbContext.Projeto.Update(projeto);
            var saved_projeto = await _dbContext.SaveChangesAsync();

            return saved_projeto;
        }
    }
}
