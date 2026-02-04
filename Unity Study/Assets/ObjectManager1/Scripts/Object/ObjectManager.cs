using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace ObjectManager1
{
    public class ObjectManager : MonoBehaviour
    {
        private TriggerManager triggerManager = null;
        private HorrorEventManager horrorEventManager = null;
        private static Dictionary<int, ObjectBase> objectDictionary = new Dictionary<int, ObjectBase>();

        private void Awake()
        {
            triggerManager = GetComponentInChildren<TriggerManager>();
            horrorEventManager = GetComponentInChildren<HorrorEventManager>();
        }

        //TEMP 
        public static ObjectBase GetObjectById(ObjectId _id)
        {
            ObjectBase result = null;

            if (objectDictionary.ContainsKey((int)_id))
            {
                result = objectDictionary[(int)_id];
            }

            return result;
        }

        public void Init()
        {
            triggerManager?.Init();
            horrorEventManager?.Init();

            var objectBaseArray = GetComponentsInChildren<ObjectBase>();

            foreach (var obj in objectBaseArray)
            {
                obj.Init();
            }

            objectDictionary = objectBaseArray.ToDictionary(obj => obj.GetId(), obj => obj);
        }

        public void DoAction(int _objectId)
        {
            if (objectDictionary.ContainsKey(_objectId))
            {
                objectDictionary[_objectId].DoAction();
            }
        }
    }
}