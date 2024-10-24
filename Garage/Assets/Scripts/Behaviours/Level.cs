using UnityEngine;

namespace Behaviours
{
    sealed class Level: MonoBehaviour
    {
        [SerializeField] private Transform _playerPlace;
        public Transform PlayerPlace => _playerPlace;

    }
}
