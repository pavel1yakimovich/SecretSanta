using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AzureSecretSanta.Infrastructure.Dependency_Injection
{
    public class AutomapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMapper>().Instance(MappingProfile.InitializeAutoMapper().CreateMapper()));
        }
    }
}