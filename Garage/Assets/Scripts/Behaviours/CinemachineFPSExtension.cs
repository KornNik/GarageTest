using Cinemachine;
using Helpers;
using Helpers.Extensions;
using UnityEngine;

namespace Behaviours
{
    sealed class CinemachineFPSExtension : CinemachineExtension
    {
        [SerializeField] private float _horizontalSpeed = 1f;
        [SerializeField] private float _verticalSpeed = 1f;
        [SerializeField] private float _clampAngle = 90f;

        private InputActions _inputs;
        private Vector3 _startingRotation;

        protected override void Awake()
        {
            base.Awake();
            _inputs = Services.Instance.Inputs.ServicesObject;
        }
        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (_startingRotation == Vector3.zero)
                {
                    _startingRotation = transform.localRotation.eulerAngles;
                    Vector2 deltaInput = _inputs.PlayerActionList[InputActionManagerPlayer.LOOK].ReadValue<Vector2>();
                    _startingRotation.x += deltaInput.x * _verticalSpeed * Time.deltaTime;
                    _startingRotation.y += deltaInput.y * _horizontalSpeed * Time.deltaTime;
                    _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                    state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
                }
            }
        }
    }
}
