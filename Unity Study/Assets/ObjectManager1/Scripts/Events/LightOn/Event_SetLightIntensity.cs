using System;
using UnityEngine;

namespace ObjectManager1
{
    public class Event_SetLightIntensity : EventBase
    {
        public override void Init()
        {
            base.Init();
            id = EventId.Event_SetLightIntensity;
        }

        public override void Execute(ObjectBase _objectBase, EventDataBase _data)
        {
            SetLightIntensity(_objectBase, _data);
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        private void SetLightIntensity(ObjectBase _object, EventDataBase _data)
        {
            var data = _data as EventData_SetLightIntensity;

            var lightComponent = _object.GetCachedComponent<Light>();
            lightComponent.intensity = data.Intensity;

            // _data.OnEventCompletedCallback?.Invoke();
        }
    }
}