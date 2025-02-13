using Behaviours.Items;
using Behaviours.Units;
using Helpers;
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

        public void StartInspection(IItem item)
        {
            if (_currentHoldItem != null) { return; }

            _currentHoldItem = item;
            _currentHoldItem.GrabItem(_holdTransform);
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
