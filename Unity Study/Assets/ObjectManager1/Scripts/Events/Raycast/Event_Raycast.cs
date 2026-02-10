using UnityEngine;

namespace ObjectManager1
{
    public class Event_Raycast : EventBase
    {
        public override void Init()
        {
            base.Init();
            id = EventId.Event_Raycast;
        }

        public override void Execute(ObjectBase _objectBase, EventDataBase _data)
        {
            var data = _data as EventData_Raycast;

            if (Physics.Raycast(_objectBase.transform.position, _objectBase.transform.forward, out RaycastHit hit, data.MaxDistance))
            {
                data.OnRaycastSuccessed?.Invoke(hit);
            }

            if (data.DrawDebugRay)
            {
                Debug.DrawRay(_objectBase.transform.position, _objectBase.transform.forward * data.MaxDistance, Color.red);
            }
        }

        public override void Stop()
        {

        }
    }
}