using System;

namespace CommandArchitecture
{
    public class Patrol02 : Patrol
    {
        public override void Init()
        {
            base.Init();
            id = (int)PatrolId.Patrol02;
        }

        public override void ExecutePatrolAction()
        {
            base.ExecutePatrolAction();

            //여기서 HorrorEvent 트리거
            CommandInvoker<OnHorrorEventTriggerParam>.Execute(new OnHorrorEventTriggerParam()
            {
                HorrorEventId = (int)HorrorEventId.HorrorEvent02,
            });
        }
    }
}