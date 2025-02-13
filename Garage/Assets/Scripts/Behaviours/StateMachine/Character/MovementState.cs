using Helpers;
using UnityEngine;

namespace Behaviours.States
{
    sealed class MovementState : CharacterState
    {
        public MovementState(CharacterStateController characterStateController) : 
            base(characterStateController)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
        }
        public override void ExitState()
        {
            base.ExitState();
            _stateController.StateObject.Movement.StopMovement();

        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }

        protected override void InputHandle()
        {
            base.InputHandle();
            var movementInputs = _inputs.InputsActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>();
            Move(movementInputs);
        }

        private void Move(Vector2 input)
        {
            _stateController.StateObject.Movement.Move(input);
        }
    }
}
