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
    public class DocumentosProjetoRepository : IDocumentosProjetoRepository
    {
        private readonly dbContext _dbContext;

        public DocumentosProjetoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DocumentosProjeto>> GetDocumentosProjeto()
        {
            var documentos = await _dbContext.DocumentosProjeto.ToListAsync();
            return documentos;
        }

        public async Task<List<DocumentosProjeto>> GetDocumentosProjetoById(int idProjeto)
        {
            var documento = await _dbContext.DocumentosProjeto.AsNoTracking().Where(x => x.IdProjeto.Equals(idProjeto)).ToListAsync();
            return documento;
        }

        public async Task<DocumentosProjeto> CreateDocumentosProjeto(DocumentosProjeto documento)
        {
            await _dbContext.DocumentosProjeto.AddAsync(documento);
            _dbContext.SaveChanges();

            return documento;
        }

        public async Task<int> UpdateDocumentosProjeto(DocumentosProjeto documento)
        {
            _dbContext.DocumentosProjeto.Update(documento);
            var saved_documento = await _dbContext.SaveChangesAsync();

            return saved_documento;
        }
    }
}
