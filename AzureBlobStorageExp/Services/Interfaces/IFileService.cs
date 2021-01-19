using System.Collections.Generic;
using System.IO;

namespace AzureBlobStorageExp.Services.Interfaces
{
    public interface IFileService
    {
        public void Create();
        public void Get();
        public void List();
        public void Update();
        public void Delete();

        public void SetFileName(string fileName);
        public void SetStream(Stream stream);
    }
}
