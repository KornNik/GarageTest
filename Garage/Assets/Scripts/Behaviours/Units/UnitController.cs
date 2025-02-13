using UnityEngine;

namespace Behaviours.Units
{
    [RequireComponent(typeof(UnitModel))]
    class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitModel _model;

        public UnitModel Model => _model;

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
