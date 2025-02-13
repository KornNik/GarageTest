using UI;
using UnityEngine;

namespace Behaviours.Units
{
    [RequireComponent(typeof(UnitModel),typeof(UnitView))]
    class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitModel _model;
        [SerializeField] private UnitView _view;

        public UnitModel Model => _model;
        public UnitView View => _view;

        private void Awake()
        {

        }
        public void UpdateInGameState()
        {
            _model.CharacterStateController.Update();
        }
        public void FixedUpdateInGameState()
        {
            _model.CharacterStateController.FixedUpdate();
        }

        public void LateUpdateInGameState()
        {
            _model.CharacterStateController.LateUpdate();
        }
    }
}
