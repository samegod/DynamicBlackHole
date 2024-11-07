using BlackHoles;
using Items.Core;
using Items.Factory;
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

        private IItemsFactory _itemsFactory;
        private float _currentDelayTime;

        [Inject]
        private void Construct(IItemsFactory itemsFactory)
        {
            _itemsFactory = itemsFactory;
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
            
            Item newItem = _itemsFactory.CreateItem(newPosition);
            newItem.MoveToTarget(blackHole);
        }
    }
}