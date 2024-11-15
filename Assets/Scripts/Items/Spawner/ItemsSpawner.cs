using BlackHoles;
using Core.ItemsPrefabs.Provider;
using Items.Core;
using Items.Factory;
using Items.Pool;
using UnityEngine;
using Zenject;

namespace Items.Spawner
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private BlackHole blackHole;
        [SerializeField] private float spawnDelay;
        [SerializeField] private Transform firstSpawnCorner;
        [SerializeField] private Transform secondSpawnCorner;
        [SerializeField, Range(0f, 1f)] private float positiveSpawnChance;
        
        private IItemsFactory _itemsFactory;
        private IItemsPrefabsProvider _prefabsProvider;
        private float _currentDelayTime;

        [Inject]
        private void Construct(IItemsFactory itemsFactory, IItemsPrefabsProvider itemsPrefabsProvider)
        {
            _itemsFactory = itemsFactory;
            _prefabsProvider = itemsPrefabsProvider;
        }
        
        private void Update()
        {
            if (_currentDelayTime <= 0)
            {
                SpawnNewItem();
                
                _currentDelayTime = spawnDelay;
            }
            else
            {
                _currentDelayTime -= Time.deltaTime;
            }
        }

        private void SpawnNewItem()
        {
            Vector3 newPosition = Vector3.zero;
            newPosition.x = Random.Range(firstSpawnCorner.position.x, secondSpawnCorner.position.x);
            newPosition.y = Random.Range(firstSpawnCorner.position.y, secondSpawnCorner.position.y);

            ItemTypeId spawnedType;
            float chance = Random.Range(0f, 1f);
            if (chance <= positiveSpawnChance)
            {
                spawnedType = ItemTypeId.Positive;
            }
            else
            {
                spawnedType = ItemTypeId.Negative;
            }

            var prefab = _prefabsProvider.PrefabsContainer.GetItemPrefab(spawnedType);
            if (!prefab)
            {
                Debug.Log("PREFAB");
                return;
            }
            Item newItem = ItemsPool.Instance.Pop(prefab);
            newItem.transform.position = newPosition;
            newItem.MoveToTarget(blackHole);
        }
    }
}