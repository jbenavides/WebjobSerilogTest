using Microsoft.Azure.WebJobs;
using TestingLogs.DI;

namespace TestingLogs
{
    class Program
    {
        
        static void Main()
        {
            var unityContainer = UnityConfig.GetConfiguredContainer();

            var config = new JobHostConfiguration()
            {
                JobActivator = new UnityActivator(unityContainer)
            };

            config.DashboardConnectionString = "DefaultEndpointsProtocol=https;AccountName=algoliastoragetest;AccountKey=X/E0OHRYvDBKz4K6eLZjZJEs9bLDwp/ZMn4E5vC+fsLu8E07QJowLVQMGy6XmVpd456h3yRDQCqCZOcrFdmWAQ==;EndpointSuffix=core.windows.net";//configurationService.Get("AzureBlobStorageEast");
            config.StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=algoliastoragetest;AccountKey=X/E0OHRYvDBKz4K6eLZjZJEs9bLDwp/ZMn4E5vC+fsLu8E07QJowLVQMGy6XmVpd456h3yRDQCqCZOcrFdmWAQ==;EndpointSuffix=core.windows.net";

            var host = new JobHost(config);

            host.RunAndBlock();

        }
    }
}
