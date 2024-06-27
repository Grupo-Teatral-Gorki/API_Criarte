using API_Criarte.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IAmazonS3Service
    {
        //Task<ApiResponse<IEnumerable<Imagens>>> GetImagensCliente(int id_empresa, string identificador_cliente);
        //Task<ApiResponse<List<Arquivos>>> GetDocsCliente(int id_empresa, string identificador_cliente);
        Task<ApiResponse<string>> GetDocById(int id_cidade, string path, string id_documento);
        //Task<bool> PutImagemCliente(int id_empresa, string identificador_cliente, string foto);
        //Task<List<ApiResponse<string>>> PutImage(int id_empresa, List<IFormFile> archive, string id_cliente, string identificador_cliente);
        Task<ApiResponse<string>> PutArchive(int id_cidade, string id_projeto, string id_documento, MemoryStream ms, IFormFile file);
        //Task<List<ApiResponse<string>>> RemoveArchive(List<RemoveArquivoClienteDTO> arquivos);
    }
}
