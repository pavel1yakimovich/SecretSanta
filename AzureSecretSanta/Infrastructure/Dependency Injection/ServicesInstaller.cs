using AzureSecretSanta.Services;
using AzureSecretSanta.Services.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AzureSecretSanta.Infrastructure.Dependency_Injection
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Where(type => type.Name.EndsWith("Service")).WithService.DefaultInterfaces());
        }
    }
}