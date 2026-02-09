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
        }

        public void DoAction(DoActionParam _param)
        {
            //EventId를 통해서 Event 가져오는 로직


            if (objectDictionary.ContainsKey((int)_param.ObjectId))
            {
                // objectDictionary[(int)_param.ObjectId].DoAction(_param.EventId);
            }
        }

        public void ExecuteEvent(int _eventId, int _targetObjectId)
        {
            if (objectDictionary.ContainsKey(_targetObjectId))
            {
                // eventManager?.ExecuteEvent(_eventId, objectDictionary[_targetObjectId]);
            }
        }
    }
}