namespace Behaviours.Units
{
    sealed class UnitAttributesContainer
    {
        private float _speedMovement;

        public UnitAttributesContainer(UnitModel unitModel)
        {
            _speedMovement = unitModel.UnitData.GetMovementAttributes();

        }
        public float SpeedMovement => _speedMovement;
    }
}
