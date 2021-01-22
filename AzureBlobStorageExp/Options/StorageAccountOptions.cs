namespace AzureBlobStorageExp.Options
{
    public class StorageAccountOptions
    {
        public string ResourceGroup { get; set; }
        public string StorageAccountName { get; set; }
        public string BlobContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}
