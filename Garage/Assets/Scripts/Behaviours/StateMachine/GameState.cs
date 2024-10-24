using UnityEngine;
using Cinemachine;
using Behaviours.Units;
using Controllers;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState<GameStateController>
    {
        PlayerLoader _playerLoader;
        LevelLoader _levelLoader;
        CinemachineVirtualCamera _camera;

        public GameState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            LoadLevelBehaviours();
            LoadPlayerBehaviours();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public override void ExitState()
        {

        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }
        private void LoadPlayerBehaviours()
        {
            _playerLoader.LoadPlayerClean();
            var cameraObject = (Services.Instance.PlayerService.ServicesObject.Model as PlayerModel).HeadTransform;
            _camera.Follow = cameraObject;
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame(0);
        }
        private void DeletLevel()
        {
            _playerLoader.DeletePlayer();
            _levelLoader.ClearLevelFull();
            _camera.Follow = null;
        }
    }
}
