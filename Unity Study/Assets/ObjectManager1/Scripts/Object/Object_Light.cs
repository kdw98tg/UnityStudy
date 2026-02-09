using UnityEngine;

namespace ObjectManager1
{
    public class Object_Light : ObjectBase
    {
        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.Object_Light;
        }

        public override void DoAction(EventBase _eventBase)
        {
            base.DoAction(_eventBase);

            EventData_SetLightIntensity data = new()
            {
                Intensity = 0f,
            };
            _eventBase.Execute(this, data);
        }
    }
}