using AzureBlobStorageExp.Services.Implementations;
using AzureBlobStorageExp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AzureBlobStorageExp.Registries
{
    public static class BusinessRegistry
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IFileService, AzureFileService>();
            services.AddTransient<IFileUploader, AzureFileUploader>();

            return services;
        }
    }
}
