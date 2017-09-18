using System;
using Microsoft.Azure;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.Storage;
using Serilog;
using Serilog.Enrichers;
using TestingLogs.Logic;

namespace TestingLogs.DI
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<Functions>();

            container.RegisterType<ILogger>(new ContainerControlledLifetimeManager(), new InjectionFactory((ctr, type, name) =>
            {
                ILogger log = new LoggerConfiguration()
                    .WriteTo.AzureTableStorage(CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=serilogstoragetesting;AccountKey=pKZler/+Tnx6jV1OhAmdrlZb71RrT/r/FgEDoYvCfSzGofC1jAnx33FmZRui//lTeIP42S788kcSzjfXQ+QcVQ==;EndpointSuffix=core.windows.net"), storageTableName:"WebjobTableStorageLogs")
                    .Enrich.With(new ThreadIdEnricher())
                    .CreateLogger();

                return log;
            }));

            container.RegisterType<ILogicTest, LogicTest>();
        }
    }
}
