namespace CommandArchitecture
{
    public class PatrolCondition03 : PatrolCondition
    {
        public override void Init()
        {
            base.Init();
            id = (int)PatrolConditionId.PatrolCondition03;
        }

        public override void UpdateProgress(int horrorEventId)
        {
            base.UpdateProgress(horrorEventId);
            OnPatrolConditionCompleted();
        }
    }
}