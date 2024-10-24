using Behaviours.Units;

namespace Behaviours.States
{
    sealed class CharacterStateController : BaseStateController
    {
        private UnitModel _stateObject;
        private IdleState _idleState;
        private MovementState _movementState;

        public IdleState IdleState => _idleState;
        public MovementState MovementState => _movementState;

        public UnitModel StateObject => _stateObject;

        public CharacterStateController(UnitModel unitModel) : base()
        {
            _stateObject = unitModel;
            InitializeStates();
            StartState(_idleState);
        }

        protected override void InitializeStates()
        {
            _idleState = new IdleState(this);
            _movementState = new MovementState(this);
        }
    }
}