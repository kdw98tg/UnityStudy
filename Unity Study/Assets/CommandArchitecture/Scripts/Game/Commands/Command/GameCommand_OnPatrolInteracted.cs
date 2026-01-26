
using System;

namespace CommandArchitecture
{
    public class GameCommand_OnPatrolInteracted : CommandBase<OnPatrolInteractedParam>
    {
        public GameCommand_OnPatrolInteracted(Action<OnPatrolInteractedParam> _action) : base(_action)
        {
        }
    }
}