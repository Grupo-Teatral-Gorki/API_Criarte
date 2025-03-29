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

        public async Task<long> CreateProjeto(Projeto projeto)
        {
            await _dbContext.Projeto.AddAsync(projeto);
            _dbContext.SaveChanges();

            return projeto.IdProjeto;
        }

        public async Task<int> UpdateProjeto(Projeto projeto)
        {
            _dbContext.Projeto.Update(projeto);
            var saved_projeto = await _dbContext.SaveChangesAsync();

            return saved_projeto;
        }

        public async Task<int> AlterarStatus(int idProjeto, string status)
        {
            var projeto = await _dbContext.Projeto.FirstOrDefaultAsync(x => x.IdProjeto == idProjeto);
            if (projeto != null)
            {
                projeto.Status = status;
                return await _dbContext.SaveChangesAsync();
            }

            return 0; // Indicate that the project was not found or not updated.
        }
    }
}
