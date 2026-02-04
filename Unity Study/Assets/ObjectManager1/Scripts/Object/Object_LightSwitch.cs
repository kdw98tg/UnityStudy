
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

        public override void DoAction()
        {
            base.DoAction();
            Debug.Log("스위치 상호작용!");
        }
    }
}