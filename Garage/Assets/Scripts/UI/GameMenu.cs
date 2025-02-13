﻿using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

namespace UI
{
    class GameMenu : BaseUI
    {
        [SerializeField] private OnScreenStick _lookJoystick;
        [SerializeField] private OnScreenStick _moveJoystick;

        private void OnEnable()
        {

        }
        private void OnDisable()
        {

        }
        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
    }
}