using System.IO;

namespace AzureBlobStorageExp.Models.Interfaces
{
    public interface IFile
    {
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
