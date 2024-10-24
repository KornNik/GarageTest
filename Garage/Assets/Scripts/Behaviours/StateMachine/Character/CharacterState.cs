using Controllers;
using Helpers;
using System;
using UnityEngine.InputSystem;


namespace Behaviours.States
{
    abstract class CharacterState : BaseState<CharacterStateController>
    {
        protected InputController _inputController;
        protected CharacterState(CharacterStateController stateController) : base()
        {
            _stateController = stateController;
            _inputController = Services.Instance.InputController.ServicesObject;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            MakeRotation();
            InputHandle();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }
        protected virtual void InputHandle()
        {
            Interact();
            Inspect();
        }

        private void Interact()
        {
            var isInteracting = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.INTERACT].IsPressed();
            if (isInteracting)
            {
                _stateController.StateObject.Interacter.CheckInteraction();
            }
        }
        private void Inspect()
        {
            var isInspecting = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.INSPECT].IsPressed();
            if (isInspecting)
            {
                _stateController.StateObject.PickUp.StartInspection();
            }
            else
            {
                _stateController.StateObject.PickUp.StopInspection();
            }
        }
        private void MakeRotation()
        {
            _stateController.StateObject.Rotation.RotateTowardCamera();
        }
    }
}