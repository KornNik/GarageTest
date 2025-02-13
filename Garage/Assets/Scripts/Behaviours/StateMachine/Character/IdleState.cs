using Helpers;

namespace Behaviours.States
{
    sealed class IdleState : CharacterState
    {
        public IdleState(CharacterStateController characterStateController) : base(characterStateController)
        {

        }
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void LogicFixedUpdate()
        {
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        public override void LogicLateUpdate()
        {

        }
        protected override void InputHandle()
        {
            base.InputHandle();
            var isMoving = _inputs.InputsActions.
                PlayerActionList[InputActionManagerPlayer.MOVEMENT].IsPressed();
            if (isMoving)
            {
                _stateController.ChangeState(_stateController.MovementState);
            }
        }
    }
}
