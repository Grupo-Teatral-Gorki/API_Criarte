using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
using API_Lib;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Services
{
    public class DocumentosProjetoService : IDocumentosProjetoService
    {
        private readonly IAmazonS3Service _s3;
        private readonly IDocumentosProjetoRepository _repository;
        private readonly dbContext _dbContext;

        public DocumentosProjetoService(IAmazonS3Service s3, dbContext dbContext, IDocumentosProjetoRepository repository)
        {
            _s3 = s3;
            _dbContext = dbContext;
            _repository = repository;
        }

        public async Task<ApiResponse<string>> PutDocumentoProjeto(int id_projeto, IFormFile file, int id_tipo)
        {
            DocumentosProjeto documento = new DocumentosProjeto
            {
                IdProjeto = id_projeto,
                NomeArquivo = file.FileName,
                Formato = Util.getFormatoArquivo(file.FileName),
                IdTipo = id_tipo,
                DataInclusao = DateTime.Now
            };

            documento = await _repository.CreateDocumentosProjeto(documento);

            Stream fileStream = file.OpenReadStream();
            MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);

            return await _s3.PutArchive(3755, $"{id_projeto}/projeto/{id_tipo}", Convert.ToString(documento.IdDocumento), ms, file);
        }

        public async Task<ApiResponse<string>> GetDocumentoProjeto(int id_projeto, int id_tipo, int id_documento)
        {
            return await _s3.GetDocById(3755, $"{id_projeto}/projeto/{id_tipo}", Convert.ToString(id_documento));
        }
    }
}
