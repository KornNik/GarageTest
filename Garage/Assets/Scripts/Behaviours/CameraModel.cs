using UnityEngine;

namespace Behaviours
{
    sealed class CameraModel : MonoBehaviour
    {
        [SerializeField] private Transform _holdObjectTransform;

        public Transform HoldObjectTransform => _holdObjectTransform; 
    }
}
