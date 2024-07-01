using API_Criarte.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IDocumentosProponenteService
    {
        Task<ApiResponse<string>> PutDocumentoProponente(int id_projeto, IFormFile file, int id_tipo);
        Task<ApiResponse<string>> GetDocumentoProponente(int id_projeto, int id_tipo, int id_documento);
    }
}
