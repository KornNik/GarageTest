﻿using Behaviours.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    sealed class MouseInput : BaseInputs
    {
        public MouseInput(UnitModel unit) : base(unit)
        {
        }

        public override void Initialization()
        {
            base.Initialization();
        }

        public override void UpdateControll()
        {
            if (Mouse.current.leftButton.IsPressed())
            {
                ProjectRay();
            }
            else
            {
                StopProject();
            }
        }

        protected override Vector2 GetScreenInputPosition()
        {
            var inputMousePosition = Mouse.current.position.ReadValue();
            var inputMousePositionWithDepth = new Vector3(inputMousePosition.x,
                inputMousePosition.y, Mathf.Abs(Camera.transform.position.z));
            var position = Camera.ScreenToWorldPoint(inputMousePositionWithDepth);
            return position;
        }

        protected override Ray GetScreenInputRay()
        {
            var inputMousePosition = Mouse.current.position.ReadValue();
            var ray = Camera.ScreenPointToRay(inputMousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            return ray;
        }
    }
}
