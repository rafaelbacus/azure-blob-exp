using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorageExp.Models.Interfaces;
using AzureBlobStorageExp.Options;
using AzureBlobStorageExp.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Services.Implementations
{
    public class AzureFileService : IFileService
    {
        private BlobServiceClient blobServiceClient;

        private string azureStorageAccountConnectionString;
        private string blobContainerName;

        private readonly AzureOptions azureOptions;

        public AzureFileService(IOptionsSnapshot<AzureOptions> snapshot)
        {
            azureOptions = snapshot.Value;
            azureStorageAccountConnectionString = azureOptions.StorageAccount.ConnectionString;
            blobContainerName = azureOptions.StorageAccount.BlobContainerName;
            blobServiceClient = new BlobServiceClient(azureStorageAccountConnectionString);
        }

        public async Task Create(IFile file)
        {
            if (string.IsNullOrWhiteSpace(file.FileName))
            {
                throw new Exception("File name not set.");
            }

            if (file.Stream == null || file.Stream.Length <= 0)
            {
                throw new Exception("No stream open.");
            }

            var blobContainerClient = await GetBlobContainerClient();
            var blobClient = blobContainerClient.GetBlobClient(file.FileName);
            await blobClient.UploadAsync(file.Stream);
        }

        private async Task<BlobContainerClient> GetBlobContainerClient()
        {
            BlobContainerClient blobContainerClient = null;

            var blobContainers = blobServiceClient.GetBlobContainersAsync();
            await foreach (var blobContainer in blobContainers)
            {
                if (blobContainer.Name.Equals(blobContainerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    blobContainerClient = blobServiceClient.GetBlobContainerClient(blobContainer.Name);
                }
            }

            if (blobContainerClient == null)
            {
                blobContainerClient = blobServiceClient.CreateBlobContainer(blobContainerName);
            }

            blobContainerClient.SetAccessPolicy(PublicAccessType.Blob);

            return blobContainerClient;
        }
    }
}
