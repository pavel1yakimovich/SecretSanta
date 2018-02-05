using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AzureSecretSanta.Infrastructure.Dependency_Injection
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Where(type => type.Name.EndsWith("Repository")).WithService.DefaultInterfaces());
        }
    }
}