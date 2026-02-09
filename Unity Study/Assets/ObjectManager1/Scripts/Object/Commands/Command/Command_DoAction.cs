using System;

namespace ObjectManager1
{
    public class Command_DoAction : CommandBase<DoActionParam>
    {
        public Command_DoAction(Action<DoActionParam> _action) : base(_action)
        {
        }
    }
}