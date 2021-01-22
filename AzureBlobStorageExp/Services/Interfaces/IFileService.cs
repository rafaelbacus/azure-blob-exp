using AzureBlobStorageExp.Models.Interfaces;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Services.Interfaces
{
    public interface IFileService
    {
        Task Create(IFile file);
        //void Get();
        //void List();
        //void Update();
        //void Delete();
    }
}
