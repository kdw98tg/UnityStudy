using UnityEngine.Rendering;

namespace CallbackArchitecture
{
    public class PatrolCondition01 : PatrolCondition
    {
        public override void Init()
        {
            base.Init();
            id = (int)PatrolConditionId.PatrolCondition01;

        }
        public override void UpdateProgress(int horrorEventId)
        {
            base.UpdateProgress(horrorEventId);
            OnPatrolConditionCompleted();
        }
    }
}