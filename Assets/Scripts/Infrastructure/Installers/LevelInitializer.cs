using Core.ItemsPrefabs;
using Core.ItemsPrefabs.Provider;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private ItemsPrefabsContainer prefabsContainer;

        private IItemsPrefabsProvider _prefabsProvider;
        
        [Inject]
        private void Construct(IItemsPrefabsProvider prefabsProvider)
        {
            _prefabsProvider = prefabsProvider;
        }
        
        public void Initialize()
        {
            Debug.Log("INIT");
            _prefabsProvider.SetPrefabsContainer(prefabsContainer);
        }
    }
}