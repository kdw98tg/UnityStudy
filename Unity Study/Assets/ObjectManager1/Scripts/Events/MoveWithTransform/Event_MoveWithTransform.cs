using System.Collections;
using UnityEngine;

namespace ObjectManager1
{
    public class Event_MoveWithTransform : EventBase
    {
        public override void Init()
        {
            base.Init();
            id = EventId.Event_MoveWithTransform;
        }

        public override void Execute(ObjectBase _objectBase, EventDataBase _data)
        {
            EventData_MoveWithTransform data = _data as EventData_MoveWithTransform;
            _objectBase.transform.position += data.Direction * data.Speed * Time.deltaTime;
        }



        public override void Stop()
        {

        }
    }
}