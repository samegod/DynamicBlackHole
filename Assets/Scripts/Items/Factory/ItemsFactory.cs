using Infrastructure.StaticData;
using Items.Core;
using UnityEngine;

namespace Items.Factory
{
    public class ItemsFactory : IItemsFactory
    {
        private readonly IStaticDataService _staticData;

        public ItemsFactory(IStaticDataService staticData)
        {
            _staticData = staticData;
        }
        
        public Item CreateItem()
        {
            return Object.Instantiate(_staticData.GetItemPrefab(ItemTypeId.Test));
        }

        public Item CreateItem(Vector3 position)
        {
            return Object.Instantiate(_staticData.GetItemPrefab(ItemTypeId.Test), position, Quaternion.identity);
        }
    }
}