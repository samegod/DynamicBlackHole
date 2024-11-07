using Infrastructure.StaticData;
using Items.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public void Initialize()
        {
            Container.Resolve<IStaticDataService>().LoadAll();
        }
        
        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindGameServices();
            BindGameFactories();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        public void BindGameServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindGameFactories()
        {
            Container.Bind<IItemsFactory>().To<ItemsFactory>().AsSingle();
        }
    }
}