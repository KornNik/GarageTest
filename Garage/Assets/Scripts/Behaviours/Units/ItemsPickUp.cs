using Behaviours.Items;
using Behaviours.Units;
using Helpers;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours
{
    sealed class ItemsPickUp : IInspecter
    {
        private const float INTERACTION_DISTANCE = 2f;
        private const float INTERACTION_SPHERE_RADIUS = 1f;

        private Camera _camera;
        private UnitModel _unitModel;
        private Transform _holdTransform;
        private IItem _currentHoldItem;

        public ItemsPickUp(UnitModel unitModel)
        {
            _unitModel = unitModel;
            _camera = Services.Instance.CameraService.ServicesObject;
            _holdTransform = Services.Instance.CameraService.ServicesObject.GetComponent<CameraModel>().HoldObjectTransform;
        }

        public float InteractionDistance { get => INTERACTION_DISTANCE; private set => InteractionDistance = value; }

        public void StartInspection()
        {
            if (_currentHoldItem != null) { return; }

            RaycastHit[] results = new RaycastHit[1];
            var hits = Physics.SphereCastNonAlloc(_camera.transform.position, INTERACTION_SPHERE_RADIUS,
                _camera.transform.forward, results, InteractionDistance, LayersManager.Item);
            if (hits > 0)
            {
                for (int i = 0; i < hits; i++)
                {
                    _currentHoldItem = results[i].collider.gameObject.GetComponent<IItem>();
                    if (_currentHoldItem != null)
                    {
                        _currentHoldItem.GrabItem(_holdTransform);
                    }
                }
            }
        }

        public void StopInspection()
        {
            if (_currentHoldItem != null)
            {
                _currentHoldItem.DropItem();
                _currentHoldItem = null;
            }
        }
    }
}
