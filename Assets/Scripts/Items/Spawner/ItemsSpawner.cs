using UnityEngine;

namespace Items.Spawner
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay;
        [SerializeField] private Transform firstSpawnCorner;
        [SerializeField] private Transform secondSpawnCorner;

        private float _currentDelayTime;
        
        private void Update()
        {
            if (_currentDelayTime <= 0)
            {
                //spawn
                _currentDelayTime = spawnDelay;
            }
            else
            {
                _currentDelayTime -= Time.deltaTime;
            }
        }
    }
}