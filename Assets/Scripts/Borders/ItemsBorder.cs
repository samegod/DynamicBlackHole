using Items.Core;
using UnityEngine;

namespace Borders
{
    public class ItemsBorder : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.transform.GetComponent<Item>();

            if (!item)
                return;

            item.Push();
        }
    }
}