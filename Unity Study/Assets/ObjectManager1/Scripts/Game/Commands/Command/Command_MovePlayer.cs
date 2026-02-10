using System;

namespace ObjectManager1
{
    public class Command_MovePlayer : CommandBase<MovePlayerParam>
    {
        public Command_MovePlayer(Action<MovePlayerParam> _action) : base(_action)
        {
        }
    }
}