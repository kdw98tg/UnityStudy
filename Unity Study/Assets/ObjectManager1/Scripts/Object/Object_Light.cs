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

        public override void DoAction(EventBase _eventBase, EventDataBase _data)
        {
            base.DoAction(_eventBase, _data);

            _eventBase.Execute(this, _data);
        }
    }
}