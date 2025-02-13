using Cinemachine;
using Behaviours.Units;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState<GameStateController>
    {
        private CinemachineVirtualCamera _camera;
        private UnitController _unit;

        public GameState(GameStateController stateController) : base()
        {
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            LoadCamera();
            _unit = Services.Instance.PlayerService.ServicesObject as UnitController;
        }

        public override void ExitState()
        {

        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _unit.UpdateInGameState();
        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
            _unit.FixedUpdateInGameState();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
            _unit.LateUpdateInGameState();
        }
        private void LoadCamera()
        {
            var cameraObject = (Services.Instance.PlayerService.ServicesObject.Model as PlayerModel).HeadTransform;
            _camera.Follow = cameraObject;
        }
    }
}
