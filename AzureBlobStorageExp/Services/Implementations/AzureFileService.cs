using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorageExp.Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace AzureBlobStorageExp.Services.Implementations
{
    public class AzureFileService : IFileService
    {        
        private BlobServiceClient blobServiceClient;
        private BlobContainerClient blobContainerClient;

        private readonly string AzureBlobConnectionString = "DefaultEndpointsProtocol=https;AccountName=rbstrgaccnt;AccountKey=DOr4gSwOUJrPKmFXpt51jhoWObHYXByZXcwP53BP8vvPU3aShNJDuKwIyOjz94OcK6LgQWRc+FaDN2Nxaae/tA==;EndpointSuffix=core.windows.net";
        private readonly string BlobContainerName = "blob-container-08281992";

        private string FileName;
        private Stream Stream;

        public AzureFileService()
        {
            blobServiceClient = new BlobServiceClient(AzureBlobConnectionString);

            var blobContainers = blobServiceClient.GetBlobContainers();
            var blobContainerItem = blobContainers.FirstOrDefault(c => c.Name.Equals(BlobContainerName, StringComparison.InvariantCultureIgnoreCase));
            if (blobContainerItem == null)
            {
                blobContainerClient = blobServiceClient.CreateBlobContainer(BlobContainerName);
            }
            else
            {
                blobContainerClient = blobServiceClient.GetBlobContainerClient(BlobContainerName);
            }

            blobContainerClient.SetAccessPolicy(PublicAccessType.Blob);
        }

        public void Create()
        {
            if (string.IsNullOrWhiteSpace(FileName))
            {
                throw new Exception("File name not set.");
            }

            if (Stream == null || Stream.Length <= 0)
            {
                throw new Exception("No stream open.");
            }

            var blobClient = blobContainerClient.GetBlobClient(FileName);
            blobClient.Upload(Stream);

            FileName = null;
            Stream.Dispose();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void List()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void SetFileName(string fileName)
        {
            FileName = fileName;   
        }

        public void SetStream(Stream stream)
        {
            Stream = stream;
        }
    }

    
}
