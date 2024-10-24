using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/Attributes/UnitData")]
    sealed class UnitData : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;

        public float GetMovementAttributes()
        {
            return _movementSpeed;
        }
    }
}
