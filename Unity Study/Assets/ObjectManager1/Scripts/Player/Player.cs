using UnityEngine;

namespace ObjectManager1
{
    public class Player : ObjectBase
    {
        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.Player;

            EventData_MoveWithTransform data = new EventData_MoveWithTransform()
            {
                MoveForwardKeyInput = KeyCode.W,
                MoveLeftKeyInput = KeyCode.A,
                MoveBackKeyInput = KeyCode.S,
                MoveRightKeyInput = KeyCode.D,
                MoveSpeed = 1f,
            };

            EventManager.GetEvent(EventId.Event_MoveWithTransform).Execute(this, data);
        }
    }
}