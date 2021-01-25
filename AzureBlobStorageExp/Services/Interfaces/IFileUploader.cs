using System.Threading.Tasks;
using AzureBlobStorageExp.Models;

namespace AzureBlobStorageExp.Services.Interfaces
{
    public interface IFileUploader
    {
        Task Upload(AzureFile file);
    }
}