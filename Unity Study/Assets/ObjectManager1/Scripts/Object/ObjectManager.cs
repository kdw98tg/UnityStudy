using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectManager1
{
    public class ObjectManager : MonoBehaviour
    {

        private TriggerManager triggerManager = null;
        private HorrorEventManager horrorEventManager = null;
        private EventManager eventManager = null;
        private static Dictionary<int, ObjectBase> objectDictionary = new Dictionary<int, ObjectBase>();


        private void Awake()
        {
            triggerManager = GetComponentInChildren<TriggerManager>();
            triggerManager = GetComponentInChildren<TriggerManager>();
            horrorEventManager = GetComponentInChildren<HorrorEventManager>();
            eventManager = GetComponentInChildren<EventManager>();
        }

        public void Init()
        {
            triggerManager?.Init();
            triggerManager?.Init();
            horrorEventManager?.Init();
            eventManager?.Init();

            var objectBaseArray = GetComponentsInChildren<ObjectBase>();

            foreach (var obj in objectBaseArray)
            {
                obj.Init();
            }

            objectDictionary = objectBaseArray.ToDictionary(obj => obj.GetId(), obj => obj);

            InitCommands();
        }

        public void DoAction(DoActionParam _param)
        {
            //EventId를 통해서 Event 가져오는 로직
            EventBase eventBase = EventManager.GetEvent(_param.EventId);

            if (objectDictionary.ContainsKey((int)_param.ObjectId))
            {
                objectDictionary[(int)_param.ObjectId].DoAction(eventBase);
            }
        }

        private void InitCommands()
        {
            CommandInvoker<DoActionParam>.Add(new Command_DoAction(DoAction));
        }
    }
}