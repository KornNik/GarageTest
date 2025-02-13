using DG.Tweening;
using UnityEngine;

namespace Behaviours.Items
{
    [RequireComponent(typeof(Collider))]
    sealed class Door : MonoBehaviour, IMovable, IInteractable
    {
        private static Vector3 OPENING_ROTATION = new Vector3(0, -80f, 0);
        private static Vector3 CLOSING_ROTATION = new Vector3(0, 0, 0);

        [SerializeField] private Transform _openingTransform;

        private bool _isAllowInteracte = true;
        private bool _isOpen = false;

        public void Interact()
        {
            if (_isAllowInteracte)
            {
                Move(Vector3.zero);
            }
        }

        public void Move(Vector3 movement)
        {
            if (!_isOpen)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }
        private void OpenDoor()
        {
            _isAllowInteracte = false;
            _openingTransform.DORotate(OPENING_ROTATION, 2f).OnComplete(() => SetStatusOnComplete(true));
        }
        private void CloseDoor()
        {
            _isAllowInteracte = false;
            _openingTransform.DORotate(CLOSING_ROTATION, 2f).OnComplete(() => SetStatusOnComplete(false));
        }
        private void SetStatusOnComplete(bool status)
        {
            _isAllowInteracte = true;
            _isOpen = status;
        }
    }
}
