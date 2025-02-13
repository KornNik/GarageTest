using Helpers;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours.Units
{
    sealed class CharacterInteraction : IInteracter
    {
        private const float INTERACTION_DISTANCE = 2f;
        private const float INTERACTION_SPHERE_RADIUS = 1f;

        private Camera _camera;
        private UnitModel _unitModel;

        public CharacterInteraction(UnitModel unitModel)
        {
            _unitModel = unitModel;
            _camera = Services.Instance.CameraService.ServicesObject;
        }

        public float InteractionDistance { get => INTERACTION_DISTANCE; private set => InteractionDistance = value; }

        public bool CheckInteraction()
        {
            RaycastHit[] results = new RaycastHit[1];
            var hits = Physics.SphereCastNonAlloc(_camera.transform.position, INTERACTION_SPHERE_RADIUS,
                _camera.transform.forward, results, InteractionDistance, LayersManager.Item);
            if (hits > 0)
            {
                for (int i = 0; i < hits; i++)
                {
                    var interactable = results[i].collider.gameObject.GetComponent<IInteractable>();
                    if (interactable != null)
                    {
                        MakeInteraction(interactable);
                        return true;
                    }
                }
            }
            return false;
        }

        public void MakeInteraction(IInteractable interactable)
        {
            interactable.Interact();
        }
    }
}
