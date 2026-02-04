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

        public override void DoAction()
        {
            base.DoAction();

            Debug.Log("불꺼짐!");
        }
    }
}