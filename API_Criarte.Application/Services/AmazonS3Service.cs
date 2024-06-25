using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
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
        //private readonly dbContextImg _dbContextImg;
        private readonly IAmazonS3Gateway _amazonService;
        //private readonly IUtilRepository _utilRepository;

        //public AmazonS3Service(dbContext dbContext, IAmazonS3Gateway amazonS3Service, dbContextImg dbContextImg, IUtilRepository utilRepository)
        public AmazonS3Service(dbContext dbContext, IAmazonS3Gateway amazonS3Service)
        {
            _dbContext = dbContext;
            _amazonService = amazonS3Service;
            //_dbContextImg = dbContextImg;
            //_utilRepository = utilRepository;
        }

        public async Task<ApiResponse<IEnumerable<Imagens>>> GetImagensCliente(int id_empresa, string identificador_cliente)
        {
            ApiResponse<IEnumerable<Imagens>> imagensL = new ApiResponse<IEnumerable<Imagens>>(true, "Ocorreu um erro desconhecido.");
            try
            {
                var imagens = await _dbContext.Imagens.FromSql(
                    $@"SELECT a.data_foto, b.descricao as tipo, 
                    a.id_foto, a.foto, a.observacoes, a.arquivo_foto, a.formato,
                    LEFT(COALESCE(a.observacoes, ''), 25) + 
                        (CASE WHEN LEN(COALESCE(a.observacoes, '')) >= 25 THEN '...' ELSE '' END) as observacoes_resumida, 
                    LEFT(COALESCE(SUBSTRING(a.arquivo_foto,CHARINDEX(':',COALESCE(a.arquivo_foto, ''))+1, LEN(COALESCE(a.arquivo_foto, ''))), ''), 25) +
                        (CASE WHEN LEN(COALESCE(SUBSTRING(a.arquivo_foto,CHARINDEX(':',COALESCE(a.arquivo_foto, ''))+1, LEN(COALESCE(a.arquivo_foto, ''))), '')) >= 25 THEN '...' ELSE '' END) as laudo_resumido,                                              
                    CAST(0 AS BIT) as selected,
                    a.estagio, a.dente_regiao, a.id_empresa, a.angulo_rotacao, a.data_alteracao, a.data_inclusao, a.id_cliente,
                    a.id_tipo_foto, a.identificador_cliente
                    FROM [SERODONTO_IMAGEM].imagens.imagens a
                    LEFT JOIN serodonto.atendimento.tipo_foto b ON b.id_tipo = a.id_tipo_foto
                    WHERE a.identificador_cliente = {identificador_cliente}
                    ORDER BY a.data_inclusao DESC"
                    ).AsNoTracking().ToListAsync();

                imagens.AsEnumerable().ToList().ForEach(row =>
                {
                    try
                    {
                        var foto = _amazonService.ReadObjectData(string.Format("{0}/imagens/", id_empresa), string.Format("{0}", row.IdFoto));

                        if (foto != null)
                        {
                            row.Foto = foto.Result;
                        }

                        //row.Tipo = !string.IsNullOrEmpty(row.Tipo) ? Convert.ToString(tipofoto.Where(x => x.IdTipo == Convert.ToInt32(row.Tipo)).Select(y => y.IdTipo)) : null;
                    }
                    catch (AmazonS3Exception s3Exception)
                    {
                        Console.WriteLine(s3Exception.Message + "\n" + s3Exception.InnerException);
                    }
                });

                imagensL.Error = false;
                imagensL.Message = "Busca realizada com sucesso.";
                imagensL.Data = imagens;
            }
            catch (Exception e)
            {
                imagensL.Error = true;
                imagensL.Message = e.Message;
            }
            return imagensL;
        }

        public async Task<ApiResponse<List<Arquivos>>> GetDocsCliente(int id_empresa, string identificador_cliente)
        {
            ApiResponse<List<Arquivos>> arquivosL = new ApiResponse<List<Arquivos>>(true, "Ocorreu um erro desconhecido.");
            try
            {
                var arquivos = await _dbContext.Arquivos.FromSql(
                $@"SELECT a.*, CONVERT(VARBINARY(MAX), NULL) as foto, b.descricao as tipo, 
                    (CAST(a.identificador_arquivo AS VARCHAR(MAX)) + '.' + a.formato) as identificador,
                    LEFT(COALESCE(a.arquivo, ''), 27) + (CASE WHEN LEN(a.arquivo) >= 27 THEN '...' ELSE '' END) as arquivo_resumido, 
                    LEFT(COALESCE(a.observacoes, ''), 25) + 
                        (CASE WHEN LEN(COALESCE(a.observacoes, '')) >= 25 THEN '...' ELSE '' END) as observacoes_resumida, 
                    CAST(0 AS BIT) as selected
                    FROM SERODONTO_IMAGEM.imagens.arquivos a
                    LEFT JOIN SERODONTO_IMAGEM.imagens.tipos_arquivos b ON b.id_tipos_arquivos = a.id_tipo
                    WHERE a.identificador_cliente = {identificador_cliente}
                    ORDER BY a.data_inclusao DESC"
                ).AsNoTracking().ToListAsync();

                arquivos.AsEnumerable().ToList().ForEach(row =>
                {
                    System.Console.WriteLine(row.Formato.ToString());
                    string nome_imagem = null;
                    if (row.IdTipo.ToString() == "1")
                    {
                        if (row.Formato.ToString() == "dcm")
                        {
                            nome_imagem = "menu/dicom.png";
                        }
                        else
                        {
                            try
                            {
                                var foto = _amazonService.ReadObjectData("/" + id_empresa.ToString() + "/arquivos", Convert.ToString(row.IdentificadorArquivo).ToUpper() + "." + row.Formato.ToString().ToLower());
                                row.Foto = foto.Result;
                            }
                            catch (AmazonS3Exception s3Exception)
                            {
                                Console.WriteLine(s3Exception.Message,
                                                    s3Exception.InnerException);
                            }
                        }
                    }
                    else
                    {
                        nome_imagem = "icone.png";
                        if (row.IdTipo.ToString() == "3" || row.Formato.ToString() == "m4a")
                        {
                            nome_imagem = "menu/audio.png";
                        }
                        else if (row.Formato.ToString() == "pdf")
                        {
                            nome_imagem = "menu/pdf.png";
                        }
                        else if (row.Formato.ToString() == "txt")
                        {
                            nome_imagem = "menu/txt.png";
                        }
                        else if (row.Formato.ToString() == "doc" || row.Formato.ToString() == "docx" || row.Formato.ToString() == "rtf")
                        {
                            nome_imagem = "menu/doc.png";
                        }
                        else if (row.Formato.ToString() == "xls" || row.Formato.ToString() == "xlsx")
                        {
                            nome_imagem = "menu/xls.png";
                        }
                        else if (row.IdTipo.ToString() == "4")
                        {
                            nome_imagem = "menu/video.png";
                        }
                    }
                    if (!string.IsNullOrEmpty(nome_imagem))
                    {
                        byte[] foto = System.IO.File.ReadAllBytes("imagens/" + nome_imagem);
                        row.Foto = foto;
                    }
                });
                arquivosL.Error = false;
                arquivosL.Message = "Busca realizada com sucesso.";
                arquivosL.Data = arquivos;
            }
            catch (Exception e)
            {
                arquivosL.Error = true;
                arquivosL.Message = e.Message;
            }
            return arquivosL;

            //ReturnArquivos arq = new ReturnArquivos();
            //arq.arq = arquivos;

            //return arquivos;
        }

        public ApiResponse<string> GetDocById(int id_empresa, string identificador_arquivo, string formato)
        {
            ApiResponse<string> apiResponse = new ApiResponse<string>(true, "Ocorreu um erro inesperado.");
            try
            {
                var foto = _amazonService.ReadObjectData(id_empresa.ToString() + "/arquivos/", Convert.ToString(identificador_arquivo).ToUpper() + "." + formato.ToString().ToLower());

                apiResponse.Error = false;
                apiResponse.Message = "Arquivo encontrado.";
                apiResponse.Data = Convert.ToBase64String(foto.Result);
            }
            catch (AmazonS3Exception s3Exception)
            {
                apiResponse.Error = true;
                apiResponse.Message = s3Exception.Message;
            }

            return apiResponse;
        }

        public async Task<List<ApiResponse<string>>> PutImage(int id_empresa, List<IFormFile> archive, string id_cliente, string identificador_cliente)
        {
            List<ApiResponse<string>> responseList = new List<ApiResponse<string>>();
            foreach (IFormFile file in archive)
            {
                string formato = getFormatoArquivo(file.FileName).ToLower();
                int id_tipo = getTipoArquivo(formato);

                Stream fileStream = file.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                fileStream.CopyTo(ms);

                string i = insertIntoFotos(id_empresa, id_cliente, identificador_cliente, formato);

                responseList.AddRange(await addToS3("imagens", i, ms, id_empresa, file, i != null ? true : false));
            }

            return responseList;
        }

        public async Task<List<ApiResponse<string>>> PutArchive(int id_empresa, List<IFormFile> archive, string identificador_cliente)
        {
            List<ApiResponse<string>> responseList = new List<ApiResponse<string>>();
            foreach(IFormFile file in archive)
            {
                Guid identificador = Guid.NewGuid();
                string identificador_arquivo = Convert.ToString(identificador);
                string formato = getFormatoArquivo(file.FileName).ToLower();
                int id_tipo = getTipoArquivo(formato);

                Stream fileStream = file.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                fileStream.CopyTo(ms);

                string arquivo_amazon = identificador_arquivo.ToUpper() + "." + formato.ToLower();

                bool i = insertIntoArquivos(identificador, id_empresa, identificador_cliente, id_tipo, file.FileName, formato);

                responseList.AddRange(await addToS3("arquivos", arquivo_amazon, ms, id_empresa, file, i));
            }

            return responseList;
        }

        public async Task<List<ApiResponse<string>>> RemoveArchive(List<RemoveArquivoClienteDTO> arquivos)
        {
            List<ApiResponse<string>> responseList = new List<ApiResponse<string>>();
            foreach(RemoveArquivoClienteDTO file in arquivos)
            {
                bool deleted = deleteArquivos(file.Path, file.Key, file.IdEmpresa, file.IdentificadorUsuario, file.NomeUsuario);

                if (deleted)
                {
                    ApiResponse<string> response = await _amazonService.DeleteAnObject($"/{file.IdEmpresa}/{file.Path}/", file.Key);
                    responseList.Add(response);
                }
                else
                {
                    ApiResponse<string> response = new ApiResponse<string>(true, "Ocorreu um erro ao deletar o registro do DataBase.");
                    responseList.Add(response);
                }
            }

            return responseList;
        }

        public async Task<bool> PutImagemCliente(int id_empresa, string identificador_cliente, string foto)
        {
            Guid identificador = Guid.Empty;
            Guid.TryParse(identificador_cliente, out identificador);

            byte[] foto_byte = Convert.FromBase64String(foto);

            await _amazonService.UploadAnObject(id_empresa + "/clientes/", identificador_cliente, foto_byte).ConfigureAwait(false);

            return true;
        }

        #region Funções auxiliares
        public async Task<List<ApiResponse<string>>> addToS3(string tipo, string arquivo_amazon, MemoryStream ms, int id_empresa, IFormFile file, bool i)
        {
            List<ApiResponse<string>> responseList = new List<ApiResponse<string>>();
            if (i)
            {
                byte[] archive_byte = ms.ToArray();

                if (await _amazonService.UploadAnObject(id_empresa + "/" + tipo + "/", arquivo_amazon, archive_byte).ConfigureAwait(false))
                {
                    responseList.Add(new ApiResponse<string>
                    (
                        false,
                        "Arquivo inserido com sucesso.",
                        file.FileName
                    ));
                }
                else
                {
                    responseList.Add(new ApiResponse<string>
                    (
                        true,
                        "Erro ao inserir arquivo na nuvem.",
                        file.FileName
                    ));
                }
            }
            else
            {
                responseList.Add(new ApiResponse<string>
                (
                    true,
                    "Erro ao inserir arquivo na tabela",
                    file.FileName
                ));
            }
            return responseList;
        }

        private string insertIntoFotos(int id_empresa, string id_cliente, string identificador_cliente, string formato)
        {
            string retorno = null;
            SqlCommand cmd = new SqlCommand(@"
            DECLARE @datafoto DATETIME = dbo.get_date(@id_empresa)

            INSERT INTO [SERODONTO_IMAGEM].imagens.imagens
            (id_empresa,id_cliente,identificador_cliente,data_foto,formato,data_inclusao) values
            (@id_empresa,@id_cliente,@identificador_cliente,@datafoto,@formato,@datafoto)                                               
            SELECT SCOPE_IDENTITY() AS id_foto");
            cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
            cmd.Parameters.AddWithValue("@identificador_cliente", identificador_cliente);
            cmd.Parameters.AddWithValue("@formato", formato);

            DataTable dt = new DataTable();
            dt = _utilRepository.runSql(cmd, true);

            if (dt.Rows.Count > 0)
            {
                retorno = Convert.ToString(dt.Rows[0][0]);
            }

            return retorno;
        }

        private bool insertIntoArquivos(Guid? identificador_arquivo, int? id_empresa, string? identificador_cliente, int? id_tipo, string? file_name, string? formato, CancellationToken cancellationToken = default)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [SERODONTO_IMAGEM].imagens.arquivos
            (identificador_arquivo, id_empresa, identificador_cliente,
            id_tipo, arquivo, formato, observacoes, data_inclusao,identificador_pagar,numero_documento,num_parcela, identificador_movimento)
            VALUES
            (@identificador_arquivo, @id_empresa, @identificador_cliente,
            @id_tipo, @file_name, @formato, null, dbo.get_date(@id_empresa), null, null, null, null)

            SELECT * FROM [SERODONTO_IMAGEM].imagens.arquivos WHERE identificador_arquivo = @identificador_arquivo");
            cmd.Parameters.AddWithValue("@identificador_arquivo", identificador_arquivo);
            cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
            cmd.Parameters.AddWithValue("@identificador_cliente", identificador_cliente);
            cmd.Parameters.AddWithValue("@id_tipo", id_tipo);
            cmd.Parameters.AddWithValue("@file_name", file_name);
            cmd.Parameters.AddWithValue("@formato", formato);

            DataTable dt = new DataTable();
            dt = _utilRepository.runSql(cmd, true);

            if(dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        private bool deleteArquivos(string path, string key, int id_empresa, string identificador_usuario, string nome_usuario)
        {
            string? query = getQueryString(path);

            if (!string.IsNullOrWhiteSpace(query))
            {
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@identificador_usuario", identificador_usuario);
                cmd.Parameters.AddWithValue("@nome_usuario", nome_usuario);
                _utilRepository.runSql(cmd, false);
                return true;
            }
            return false;
        }

        public string? getQueryString(string path)
        {
            string imagens = @"
            DECLARE @nome_arquivo VARCHAR(MAX)
            DECLARE @identificador VARCHAR(MAX)

            SELECT @nome_arquivo = observacoes + '.' + formato, @identificador = UPPER(identificador_cliente) FROM [SERODONTO_IMAGEM].imagens.imagens
            WHERE id_foto = @key

            DELETE FROM [SERODONTO_IMAGEM].imagens.imagens where id_foto = @key
                    
            EXEC [seguranca].[st_log_alteracao_insert] @id_empresa, 'IMAGENS', @identificador_usuario, @nome_usuario, 
            'APAGAR', @key, @nome_arquivo, '',@identificador";

            string arquivos = @"
            BEGIN
                DECLARE @nome_arquivo VARCHAR(MAX)

                SELECT @nome_arquivo = arquivo FROM [SERODONTO_IMAGEM].imagens.arquivos
                WHERE identificador_arquivo = @key

                DELETE FROM [SERODONTO_IMAGEM].imagens.arquivos
                WHERE id_empresa = @id_empresa
                AND identificador_arquivo = @key

                EXEC [seguranca].[st_log_alteracao_insert] @id_empresa, 'ARQUIVOS', @identificador_usuario, @nome_usuario, 
                'APAGAR', @key, @nome_arquivo, '',''
            END"
            ;
            return "imagens".Contains(path.ToLower()) ? imagens : "arquivos".Contains(path.ToLower()) ? arquivos : null;
        }

        public static string getFormatoArquivo(string arquivo)
        {
            string formato = "";
            if (arquivo != null && arquivo.Contains("."))
                formato = arquivo.Substring(arquivo.LastIndexOf(".") + 1);
            return formato;
        }

        protected int getTipoArquivo(string formato)
        {
            if (formato == "jpg" || formato == "jpeg" || formato == "png" || formato == "bmp" || formato == "gif" || formato == "tif" || formato == "tiff" || formato == "dcm")
            {
                return 1;
            }
            else if (formato == "txt" || formato == "pdf" || formato == "doc" || formato == "docx" || formato == "xls" || formato == "xlsx" || formato == "rtf")
            {
                return 2;
            }
            else if (formato == "mp3" || formato == "wav" || formato == "3gpp")
            {
                return 3;
            }
            else if (formato == "mp4" || formato == "webm" || formato == "wmv" || formato == "avi")
            {
                return 4;
            }
            else if (formato == "zip" || formato == "rar" || formato == "stl")
            {
                return 5;
            }
            return 0;
        }
        #endregion
    }
}
