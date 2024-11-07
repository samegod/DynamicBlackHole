using Items.Core;
using UnityEngine;

namespace Items.Factory
{
    public interface IItemsFactory
    {
        Item CreateItem();
        Item CreateItem(Vector3 position);
    }
}