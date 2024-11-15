using System.Collections.Generic;
using System.Linq;
using Additions.Extensions;
using Items.Core;
using UnityEngine;

namespace Core.ItemsPrefabs
{
    public class ItemsPrefabsContainer : MonoBehaviour
    {
        [SerializeField] private List<Item> _prefabs;

        [SerializeField] private float _currentMass;

        public void SetMass(float mass)
        {
            _currentMass = mass;
        }

        public Item GetItemPrefab(ItemTypeId typeId)
        {
            List<Item> possibleItems = _prefabs.Where(x =>
                x.LowestAppearMass <= _currentMass &&
                x.HighestAppearMass >= _currentMass &&
                x.TypeId == typeId)
                .ToList();

            if (possibleItems.Count == 0)
            {
                return null;
            }
            
            return possibleItems.GetRandomElement();
        }
    }
}