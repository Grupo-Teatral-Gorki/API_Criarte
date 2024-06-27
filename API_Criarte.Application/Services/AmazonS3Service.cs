using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using API_Criarte.Application.Interfaces;
using API_Criarte.Infra.Data.Context;
using API_Criarte.Application.Interfaces.Gateway;
using API_Criarte.Domain;

namespace API_Criarte.Application.Services
{
    public class AmazonS3Service : IAmazonS3Service
    {
        private readonly dbContext _dbContext;
        private readonly IAmazonS3Gateway _amazonService;
        
        public AmazonS3Service(dbContext dbContext, IAmazonS3Gateway amazonS3Service)
        {
            _dbContext = dbContext;
            _amazonService = amazonS3Service;
        }

        public async Task<ApiResponse<string>> GetDocById(int id_cidade, string path, string id_documento)
        {
            ApiResponse<string> apiResponse = new ApiResponse<string>(true, "Ocorreu um erro inesperado.");
            try
            {
                var doc = await _amazonService.ReadObjectData($"{id_cidade}/{path}/", id_documento);

                apiResponse.Error = false;
                apiResponse.Message = "Arquivo encontrado.";
                apiResponse.Data = Convert.ToBase64String(doc);
            }
            catch (AmazonS3Exception s3Exception)
            {
                apiResponse.Error = true;
                apiResponse.Message = s3Exception.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse<string>> PutArchive(int id_cidade, string path, string id_documento, MemoryStream ms, IFormFile file)
        {
            var result = new ApiResponse<string>
                (
                    true,
                    "Erro ao inserir arquivo na nuvem.",
                    file.FileName
                );

            byte[] archive_byte = ms.ToArray();

            if (await _amazonService.UploadAnObject($"{id_cidade}/{path}/", id_documento, archive_byte, file.ContentType).ConfigureAwait(false))
            {
                return new ApiResponse<string>
                (
                    false,
                    "Arquivo inserido com sucesso.",
                    file.FileName
                );
            }

            return result;
        }

        //public async Task<List<ApiResponse<string>>> RemoveArchive(List<RemoveArquivoClienteDTO> arquivos)
        //{
        //    List<ApiResponse<string>> responseList = new List<ApiResponse<string>>();
        //    foreach(RemoveArquivoClienteDTO file in arquivos)
        //    {
        //        bool deleted = deleteArquivos(file.Path, file.Key, file.IdEmpresa, file.IdentificadorUsuario, file.NomeUsuario);

        //        if (deleted)
        //        {
        //            ApiResponse<string> response = await _amazonService.DeleteAnObject($"/{file.IdEmpresa}/{file.Path}/", file.Key);
        //            responseList.Add(response);
        //        }
        //        else
        //        {
        //            ApiResponse<string> response = new ApiResponse<string>(true, "Ocorreu um erro ao deletar o registro do DataBase.");
        //            responseList.Add(response);
        //        }
        //    }

        //    return responseList;
        //}
    }
}
