using Core.Growth;
using Core.ItemsPrefabs.Provider;
using Infrastructure.StaticData;
using Items.Factory;
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
            BindProviders();
            BindGameServices();
            BindGameFactories();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<IItemsPrefabsProvider>().To<ItemsPrefabsProvider>().AsSingle();
        }

        private void BindGameServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IGrowthManager>().To<GrowthManager>().AsSingle();
        }

        private void BindGameFactories()
        {
            Container.Bind<IItemsFactory>().To<ItemsFactory>().AsSingle();
        }
    }
}