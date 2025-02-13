using Inputs;

namespace Behaviours.States
{
    abstract class CharacterState : BaseState<CharacterStateController>
    {
        protected BaseInputs _inputs;
        protected CharacterState(CharacterStateController stateController) : base()
        {
            _stateController = stateController;
            _inputs = new InputFactory().GetInputs(_stateController.StateObject);
        }
        public override void EnterState()
        {
            base.EnterState();
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
            _inputs.Update();
        }
        private void MakeRotation()
        {
            _stateController.StateObject.Rotation.RotateTowardCamera();
        }
    }
}