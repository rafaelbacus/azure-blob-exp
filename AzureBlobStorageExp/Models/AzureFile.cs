using AzureBlobStorageExp.Models.Interfaces;
using System;
using System.IO;

namespace AzureBlobStorageExp.Models
{
    public class AzureFile : IFile, IDisposable
    {
        public Uri Uri { get; set; }
        public string FileName { get; set; }
        public Stream Stream { get; set; }

        public AzureFile()
        {
        }

        public AzureFile(string fileName)
        {
            FileName = fileName;
        }

        public AzureFile(string fileName, Stream stream)
        {
            FileName = fileName;
            Stream = stream;
        }

        public void Dispose()
        {
            Stream.Dispose();
        }
    }
}
