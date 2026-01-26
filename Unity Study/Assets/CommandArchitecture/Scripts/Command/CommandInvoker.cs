using System;
using System.Collections.Generic;

namespace CommandArchitecture
{
    public class CommandInvoker<T>
    {
        private static readonly Dictionary<Type, ICommand<T>> commandDictionary = new();

        public static void Add(ICommand<T> _command)
        {
            commandDictionary.Add(typeof(T), _command);
        }

        public static void Execute(T _param)
        {
            var type = typeof(T);

            if (commandDictionary.ContainsKey(type))
            {
                commandDictionary[type].Execute(_param);
            }
        }

    }
}