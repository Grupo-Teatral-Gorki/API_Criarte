using Amazon.S3;
using API_Criarte.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces.Gateway
{
    public interface IAmazonS3Gateway
    {
        Task<bool> UploadAnObject(string path, string file_name, byte[] file, string content_type);
        Task<bool> UploadFileAsync(IAmazonS3 client, string bucketName, string objectName, string filePath);
        Task<byte[]> ReadObjectData(string path, string key);
        Task<ApiResponse<string>> DeleteAnObject(string path, string key);
    }
}
