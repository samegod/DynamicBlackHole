using System;
using System.Collections.Generic;
using System.Linq;
using Items.Core;
using UnityEngine;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ItemTypeId, Item> _itemsById;
        
        public void LoadAll()
        {
            LoadItems();
        }

        public Item GetItemPrefab(ItemTypeId typeId)
        {
            if (_itemsById.TryGetValue(typeId, out var config))
                return config;

            throw new Exception($"Item prefab for {typeId} was not found");
        }
        
        private void LoadItems()
        {
            _itemsById = Resources
                .LoadAll<Item>("Prefabs/Items")
                .ToDictionary(x => x.TypeId, x => x);
        }
    }
}