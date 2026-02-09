using System;
using ObjectManager1;

public class Command_ExecuteEvent : CommandBase<ExecuteEventParam>
{
    public Command_ExecuteEvent(Action<ExecuteEventParam> _action) : base(_action)
    {
    }
}