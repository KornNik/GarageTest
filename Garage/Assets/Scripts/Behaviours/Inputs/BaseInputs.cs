using Behaviours;
using Behaviours.Items;
using Behaviours.Units;
using Controllers;
using Helpers;
using Helpers.Extensions;
using Helpers.Managers;
using UnityEngine;

namespace Inputs
{
    abstract class BaseInputs : IInitialization
    {
        private Camera _camera;
        private UnitModel _unit;
        private InputActions _inputsActions;

        protected RaycastHit _hit;

        public BaseInputs(UnitModel unit)
        {
            _unit = unit;
            Initialization();
        }

        public Camera Camera => _camera;
        public InputActions InputsActions => _inputsActions;

        public virtual void Initialization()
        {
            _camera = Services.Instance.CameraService.ServicesObject;
            _inputsActions = Services.Instance.Inputs.ServicesObject;
        }
        public void Update()
        {
            UpdateControll();
        }

        protected void ProjectRay()
        {
            var ray = GetScreenInputRay();
            var isHit = Physics.Raycast(ray.origin, ray.direction,out _hit, 5f, LayersManager.Item);
            if (isHit)
            {
                var interactObject = _hit.transform.GetComponent<IInteractable>();
                if(interactObject != null)
                {
                    Interact(interactObject);
                }
                var itemObject = _hit.transform.GetComponent<IItem>();
                if(itemObject != null)
                {
                    Inspect(itemObject);
                }
            }
        }
        protected void StopProject()
        {
            Drop();
        }
        private void Interact(IInteractable interactable)
        {
            _unit.Interacter.MakeInteraction(interactable);
        }
        private void Inspect(IItem item)
        {
            _unit.PickUp.StartInspection(item);
        }
        private void Drop()
        {
            _unit.PickUp.StopInspection();
        }

        public abstract void UpdateControll();

        protected abstract Ray GetScreenInputRay();
        protected abstract Vector2 GetScreenInputPosition();
    }
}
