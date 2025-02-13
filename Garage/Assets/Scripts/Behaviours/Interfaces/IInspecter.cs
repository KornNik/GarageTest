using Behaviours.Items;

namespace Behaviours
{
    interface IInspecter
    {
        void StartInspection(IItem item);
        void StopInspection();
    }
}
