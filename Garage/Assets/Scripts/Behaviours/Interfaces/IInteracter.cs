using UnityEngine;

namespace Behaviours
{
    interface IInteracter
    {
        float InteractionDistance { get;}
        void MakeInteraction(IInteractable<Transform> interactable);
        bool CheckInteraction();
    }
}
