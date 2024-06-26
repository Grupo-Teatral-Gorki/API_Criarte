using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IDocumentosProjetoRepository
    {
        Task<List<DocumentosProjeto>> GetDocumentosProjeto();
        Task<List<DocumentosProjeto>> GetDocumentosProjetoById(int idProjeto);
        Task<DocumentosProjeto> CreateDocumentosProjeto(DocumentosProjeto documento);
        Task<int> UpdateDocumentosProjeto(DocumentosProjeto documento);
    }
}
