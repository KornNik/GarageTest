using Inputs;
using UnityEngine;
using Behaviours.Units;

namespace Behaviours
{
    sealed class InputFactory
    {
        public BaseInputs GetInputs(UnitModel unit)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new TouchScreenInput(unit);
            }
            else
            {
                return new MouseInput(unit);
            }
        }
    }
}
