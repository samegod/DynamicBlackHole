namespace Core.ItemsPrefabs.Provider
{
    public class ItemsPrefabsProvider : IItemsPrefabsProvider
    {
        public ItemsPrefabsContainer PrefabsContainer { get; private set; }

        public void SetPrefabsContainer(ItemsPrefabsContainer container)
        {
            PrefabsContainer = container;
        }
    }
}