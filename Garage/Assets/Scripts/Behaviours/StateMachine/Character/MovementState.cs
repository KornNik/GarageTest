using Helpers;
using UnityEngine;

namespace Behaviours.States
{
    class MovementState : CharacterState
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
            var movementInputs = _inputController.InputActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>();
            _stateController.StateObject.Movement.Move(movementInputs);
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }

        protected override void InputHandle()
        {
            base.InputHandle();
            var isMoving = _inputController.InputActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].IsPressed();
            if(!isMoving)
            {
                _stateController.ChangeState(_stateController.IdleState);
            }
        }
    }
}
