using Items.Core;

namespace Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        Item GetItemPrefab(ItemTypeId typeId);
    }
}