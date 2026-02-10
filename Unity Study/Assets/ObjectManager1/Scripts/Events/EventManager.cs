using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectManager1
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<int, EventBase> eventBaseDictionary = null;

        public void Init()
        {
            var eventBaseArray = GetComponentsInChildren<EventBase>();

            foreach (var events in eventBaseArray)
            {
                events.Init();
            }

            eventBaseDictionary = eventBaseArray.ToDictionary(eventBase => (int)eventBase.GetId(), eventBase => eventBase);

            InitCommands();
        }

        public void ExecuteEvent(ExecuteEventParam _param)
        {
            if (eventBaseDictionary.ContainsKey((int)_param.EventId))
            {
                eventBaseDictionary[(int)_param.EventId].Execute(_param.TargetObject, null);
            }
        }

        public EventBase GetEvent(EventId _id)
        {
            EventBase result = null;

            if (eventBaseDictionary.ContainsKey((int)_id))
            {
                result = eventBaseDictionary[(int)_id];
            }

            return result;
        }

        private void InitCommands()
        {
            CommandInvoker<ExecuteEventParam>.Add(new Command_ExecuteEvent(ExecuteEvent));
        }
    }
}