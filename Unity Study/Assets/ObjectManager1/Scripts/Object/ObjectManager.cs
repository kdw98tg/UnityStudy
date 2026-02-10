using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectManager1
{
    public class ObjectManager : MonoBehaviour
    {
        private static Dictionary<int, ObjectBase> objectDictionary = new Dictionary<int, ObjectBase>();

        public void Init()
        {
            var objectBaseArray = GetComponentsInChildren<ObjectBase>();

            foreach (var obj in objectBaseArray)
            {
                obj.Init();
            }

            objectDictionary = objectBaseArray.ToDictionary(obj => obj.GetId(), obj => obj);


        }

        public void DoAction(ObjectId _id, EventBase _event, EventDataBase _eventData)
        {
            if (objectDictionary.ContainsKey((int)_id))
            {
                objectDictionary[(int)_id].DoAction(_event, _eventData);
            }
        }


    }
}