using System;

namespace CommandArchitecture
{
    public class Patrol03 : Patrol
    {
        public override void Init(Action<int> _onPatrolInteracted, Action<int> _onHorrorEventTrigger)
        {
            base.Init(_onPatrolInteracted, _onHorrorEventTrigger);
            id = (int)PatrolId.Patrol03;
        }

        public override void ExecutePatrolAction()
        {
            base.ExecutePatrolAction();

            //여기서 HorrorEvent 트리거
            onHorrorEventTrigger?.Invoke((int)HorrorEventId.HorrorEvent03);
        }
    }
}