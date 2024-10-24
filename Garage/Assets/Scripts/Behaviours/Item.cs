using DG.Tweening;
using UnityEngine;

namespace Behaviours.Items
{
    [RequireComponent(typeof(Rigidbody),typeof(Collider))]
    class Item : MonoBehaviour, IItem
    {
        private Rigidbody _rigidbody;
        private Collider _interactionCollider;
        private Transform _holdTransform;

        private bool _isAllowInteract = true;
        private bool _isHolding = false;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _interactionCollider = GetComponent<Collider>();
        }

        public void DropItem()
        {
            _isAllowInteract = true;
            _rigidbody.useGravity = true;
            _interactionCollider.enabled = true;
            _holdTransform = null;
            _isHolding = false;
        }

        public void GrabItem(Transform grabTransform)
        {
            _holdTransform = grabTransform;
            _isAllowInteract = false;
            _rigidbody.useGravity = false;
            _interactionCollider.enabled = false;
            _isHolding = true;
        }

        private void FixedUpdate()
        {
            if(_isHolding)
            {
                if (_holdTransform != null)
                {
                    _rigidbody.DOMove(_holdTransform.position, 0.1f);
                }
            }
        }
    }
}
