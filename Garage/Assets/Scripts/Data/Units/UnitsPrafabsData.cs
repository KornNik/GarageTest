using Behaviours.Units;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitsPrefabs", menuName = "Data/Units/Prafabs")]
    sealed class UnitsPrafabsData : ScriptableObject
    {
        [SerializeField] private UnitController _playerUnit;

        public UnitController GetPlayer()
        {
            return _playerUnit;
        }
    }
}
