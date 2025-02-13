using Helpers;
using System.Threading.Tasks;
using System;
using Controllers;

namespace Behaviours
{
    sealed class LoadLevelState : BaseState<GameStateController>
    {
        private PlayerLoader _playerLoader;
        private LevelLoader _levelLoader;

        public LoadLevelState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }
        private async void LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(CreateUnits);
            await LoadTask(StartGameState);
        }

        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame(0);
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
        private void CreateUnits()
        {
            _playerLoader.LoadPlayerClean();
        }
    }
}
