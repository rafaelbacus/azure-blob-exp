using AzureBlobStorageExp.Models;
using AzureBlobStorageExp.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Services.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<AzureFile>> ListFiles();
    }
}
