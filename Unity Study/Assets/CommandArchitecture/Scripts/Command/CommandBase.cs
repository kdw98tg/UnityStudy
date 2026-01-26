using System;

namespace CommandArchitecture
{
    public class CommandBase<T> : ICommand<T> where T : IParam
    {
        private Action<T> action = null;

        public CommandBase(Action<T> _action)
        {
            action = _action;
        }

        public void Execute(T _param)
        {
            action?.Invoke(_param);
        }
    }
}