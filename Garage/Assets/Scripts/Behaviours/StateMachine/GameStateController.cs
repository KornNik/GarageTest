using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    sealed class GameStateController : BaseStateController,
        IEventListener<ChangeGameStateEvent>, IEventSubscription
    {
        private Dictionary<GameStateType, IState> _states = 
            new Dictionary<GameStateType, IState>(5);

        public GameStateController()
        {
            InitializeStates();
            StartState(GetState(GameStateType.MenuState));
        }

        protected override void InitializeStates()
        {
            _states.Clear();
            _states.Add(GameStateType.MenuState, new MenuState(this));
            _states.Add(GameStateType.GameState, new GameState(this));
            _states.Add(GameStateType.LoadLevelState, new LoadLevelState(this));
        }

        public void OnEventTrigger(ChangeGameStateEvent eventType)
        {
            ChangeState(GetState(eventType.NextGameState));
        }
        private IState GetState(GameStateType gameState)
        {
            if (_states.ContainsKey(gameState))
            {
                var state = _states[gameState];
                return state;
            }
            return null;
        }

        public void Subscribe()
        {
            this.EventStartListening<ChangeGameStateEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }
    }
}