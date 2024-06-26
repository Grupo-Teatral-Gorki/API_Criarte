using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces.Gateway;
using API_Criarte.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Gateway
{
    public class AmazonS3Gateway : IAmazonS3Gateway
    {
        public string AwsKeyID { get; private set; }
        public string AwsKeySecret { get; private set; }
        public string bucketName { get; private set; }
        public BasicAWSCredentials AWSCredentials { get; private set; }

        private readonly IAmazonS3 _awsS3Client;

        public AmazonS3Gateway(IOptions<AwsVariablesDTO> variables)
        {
            AwsKeyID = variables.Value.AwsKeyID;
            AwsKeySecret = variables.Value.AwsKeySecret;
            bucketName = variables.Value.bucketName;

            AWSCredentials = new BasicAWSCredentials(AwsKeyID, AwsKeySecret);

            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };

            _awsS3Client = new AmazonS3Client(AWSCredentials, config);
        }

        public async Task<bool> UploadAnObject(string path, string file_name, byte[] file)
        {
            using (Stream stream = new MemoryStream(file))
            {
                var request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.InputStream = stream;
                request.Key = path + file_name;
                request.ContentType = "image/png"; //file.ContentType;
                request.StorageClass = S3StorageClass.Standard;
                request.CannedACL = S3CannedACL.BucketOwnerFullControl;
                var response = await _awsS3Client.PutObjectAsync(request).ConfigureAwait(false);

                return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? true : false;
            }
        }

        public async Task<ApiResponse<string>> DeleteAnObject(string path, string key)
        {
            ApiResponse<string> response = new ApiResponse<string>(true, "Ocorreu um erro ao deletar o arquivo.", key);
            DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = path + key
            };
            try
            {
                var aws = await _awsS3Client.DeleteObjectAsync(deleteObjectRequest).ConfigureAwait(false);
                response.Error = false;
                response.Message = "Arquivo deletado com sucesso.";
            }
            catch (AmazonS3Exception s3Exception)
            {
                response.Error = true;
                response.Message = s3Exception.Message;
            }
            return response;
        }

        public async Task<bool> UploadFileAsync(
            IAmazonS3 client,
            string bucketName,
            string objectName,
            string filePath)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectName,
                FilePath = filePath,
            };

            var response = await client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Successfully uploaded {objectName} to {bucketName}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Could not upload {objectName} to {bucketName}.");
                return false;
            }
        }

        public async Task<byte[]> ReadObjectData(
            string path,
            string key)
        {
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = path + key,
            };

            // Issue request and remember to dispose of the response
            using GetObjectResponse response = await _awsS3Client.GetObjectAsync(request);

            using (Stream responseStream = response.ResponseStream)
            {
                byte[] buffer = new byte[responseStream.Length];

                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}
