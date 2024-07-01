using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IDocumentosProponenteRepository
    {
        Task<List<DocumentosProponente>> GetDocumentosProponente();
        Task<List<DocumentosProponente>> GetDocumentosProponenteById(int idProjeto);
        Task<DocumentosProponente> CreateDocumentosProponente(DocumentosProponente documento);
        Task<int> UpdateDocumentosProponente(DocumentosProponente documento);
    }
}
