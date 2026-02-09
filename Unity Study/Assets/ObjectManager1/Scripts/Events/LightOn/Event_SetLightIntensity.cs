using UnityEngine;

namespace ObjectManager1
{
    public class Event_LightOn : EventBase
    {
        public override void Init()
        {
            base.Init();
            id = EventId.Event_LightOff;
        }
        public override void Execute(ObjectBase _objectBase, EventDataBase _data)
        {
            TurnOnLight(_objectBase, _data);
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        private void TurnOnLight(ObjectBase _object, EventDataBase _data)
        {
            var data = _data as EventData_SetLightIntensity;

            var lightComponent = _object.GetCachedComponent<Light>();
            lightComponent.intensity = data.Intensity;
        }
    }
}