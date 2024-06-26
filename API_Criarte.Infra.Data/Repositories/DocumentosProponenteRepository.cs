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
    public class DocumentosProponenteRepository : IDocumentosProponenteRepository
    {
        private readonly dbContext _dbContext;

        public DocumentosProponenteRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DocumentosProponente>> GetDocumentosProponente()
        {
            var documentos = await _dbContext.DocumentosProponente.ToListAsync();
            return documentos;
        }

        public async Task<List<DocumentosProponente>> GetDocumentosProponenteById(int idProjeto)
        {
            var documento = await _dbContext.DocumentosProponente.AsNoTracking().Where(x => x.IdProjeto.Equals(idProjeto)).ToListAsync();
            return documento;
        }

        public async Task<DocumentosProponente> CreateDocumentosProponente(DocumentosProponente documento)
        {
            await _dbContext.DocumentosProponente.AddAsync(documento);
            _dbContext.SaveChanges();

            return documento;
        }

        public async Task<int> UpdateDocumentosProponente(DocumentosProponente documento)
        {
            _dbContext.DocumentosProponente.Update(documento);
            var saved_documento = await _dbContext.SaveChangesAsync();

            return saved_documento;
        }
    }
}
