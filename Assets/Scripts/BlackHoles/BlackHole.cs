using Core.Growth;
using Items.Core;
using ItemsTarget;
using UnityEngine;
using Zenject;

namespace BlackHoles
{
    public class BlackHole : Target
    {
        private IGrowthManager _growthManager;

        [Inject]
        private void Construct(IGrowthManager growthManager)
        {
            _growthManager = growthManager;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.transform.GetComponent<Item>();

            if (!item)
                return;

            ConsumeItem(item);
        }

        private void ConsumeItem(Item item)
        {
            if (item.TypeId == ItemTypeId.Positive)
            {
                _growthManager.AddMass(item.Mass);
            }
            else if (item.TypeId == ItemTypeId.Negative)
            {
                _growthManager.ReduceMass(item.Mass);
            }

            item.Push();
        }
    }
}