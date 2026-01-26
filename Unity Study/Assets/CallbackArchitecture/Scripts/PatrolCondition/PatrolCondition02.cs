namespace CallbackArchitecture
{
    public class PatrolCondition02 : PatrolCondition
    {
        public override void Init()
        {
            base.Init();
            id = (int)PatrolConditionId.PatrolCondition02;
        }

        public override void UpdateProgress(int horrorEventId)
        {
            base.UpdateProgress(horrorEventId);
            OnPatrolConditionCompleted();
        }
    }
}