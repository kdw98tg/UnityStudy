using UnityEngine;

namespace ObjectManager1
{
    public class Object_LightSwitch : ObjectBase
    {
        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.Object_LightSwitch;
        }

        public override void DoAction(EventBase _eventBase, EventDataBase _data)
        {
            base.DoAction(_eventBase, _data);
        }
    }
}