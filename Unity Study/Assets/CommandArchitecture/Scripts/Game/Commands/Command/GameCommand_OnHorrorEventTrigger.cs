
using System;

namespace CommandArchitecture
{
    public class GameCommand_OnHorrorEventTrigger : CommandBase<OnHorrorEventTriggerParam>
    {
        public GameCommand_OnHorrorEventTrigger(Action<OnHorrorEventTriggerParam> _action) : base(_action)
        {
        }
    }
}