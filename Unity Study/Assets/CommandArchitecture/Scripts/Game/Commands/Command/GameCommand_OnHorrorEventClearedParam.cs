
using System;

namespace CommandArchitecture
{
    public class GameCommand_OnHorrorEventClearedParam : CommandBase<OnHorrorEventClearedParam>
    {
        public GameCommand_OnHorrorEventClearedParam(Action<OnHorrorEventClearedParam> _action) : base(_action)
        {
        }
    }
}