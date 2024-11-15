using Core.ItemsPrefabs.Provider;

namespace Core.Growth
{
    public class GrowthManager : IGrowthManager
    {
        private readonly IItemsPrefabsProvider _prefabsProvider;
        private float _currentMass;
        
        public GrowthManager(IItemsPrefabsProvider prefabsProvider)
        {
            _prefabsProvider = prefabsProvider;
        }
        
        public void AddMass(float mass)
        {
            _currentMass += mass;
            _prefabsProvider.PrefabsContainer.SetMass(_currentMass);
        }

        public void ReduceMass(float mass)
        {
            _currentMass -= mass;
            if (_currentMass < 0)
            {
                _currentMass = 0;
            }
            _prefabsProvider.PrefabsContainer.SetMass(_currentMass);
        }
    }
}