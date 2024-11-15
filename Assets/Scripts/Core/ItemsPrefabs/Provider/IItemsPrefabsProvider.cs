namespace Core.ItemsPrefabs.Provider
{
    public interface IItemsPrefabsProvider
    {
        ItemsPrefabsContainer PrefabsContainer { get; }
        void SetPrefabsContainer(ItemsPrefabsContainer container);
    }
}