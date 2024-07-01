using API_Criarte.Application.Interfaces;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using API_Lib;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Infra.Data.Context;

namespace API_Criarte.Application.Services
{
    public class DocumentosProponenteService : IDocumentosProponenteService
    {
        private readonly IAmazonS3Service _s3;
        private readonly IDocumentosProponenteRepository _repository;
        private readonly dbContext _dbContext;

        private readonly IHttpContextAccessor user;
        private int id_cidade;

        public DocumentosProponenteService(IAmazonS3Service s3, dbContext dbContext, IDocumentosProponenteRepository repository, 
            IHttpContextAccessor user)
        {
            _s3 = s3;
            _dbContext = dbContext;
            _repository = repository;
            this.user = user;

            id_cidade = Convert.ToInt32(AlterClaim.GetClaimValue(this.user.HttpContext.User, "id_cidade"));
        }

        public async Task<ApiResponse<string>> PutDocumentoProponente(int id_projeto, IFormFile file, int id_tipo)
        {
            DocumentosProponente documento = new DocumentosProponente
            {
                IdProjeto = id_projeto,
                NomeArquivo = file.FileName,
                Formato = Util.getFormatoArquivo(file.FileName),
                IdTipo = id_tipo,
                DataInclusao = DateTime.Now
            };

            documento = await _repository.CreateDocumentosProponente(documento);

            Stream fileStream = file.OpenReadStream();
            MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);

            return await _s3.PutArchive(id_cidade, $"{id_projeto}/proponente/{id_tipo}", Convert.ToString(documento.IdDocumento), ms, file);
        }

        public async Task<ApiResponse<string>> GetDocumentoProponente(int id_projeto, int id_tipo, int id_documento)
        {
            return await _s3.GetDocById(id_cidade, $"{id_projeto}/proponente/{id_tipo}", Convert.ToString(id_documento));
        }
    }
}
