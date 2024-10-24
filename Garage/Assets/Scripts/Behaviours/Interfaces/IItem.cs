using UnityEngine;

namespace Behaviours.Items
{
    interface IItem
    {
        void DropItem();
        void GrabItem(Transform transform);
    }
}
