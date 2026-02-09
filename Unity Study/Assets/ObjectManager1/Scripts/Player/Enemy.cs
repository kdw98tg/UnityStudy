using UnityEngine;

namespace ObjectManager1
{
    public class Enemy : ObjectBase
    {
        private EventBase moveEvent = null;

        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.Enemy;

            moveEvent = EventManager.GetEvent(EventId.Event_MoveWithTransform);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartMoving();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                StopMoving();
            }
        }

        private void StartMoving()
        {
            EventData_MoveWithTransform data = new EventData_MoveWithTransform()
            {
                MoveForwardKeyInput = KeyCode.UpArrow,
                MoveLeftKeyInput = KeyCode.LeftArrow,
                MoveBackKeyInput = KeyCode.DownArrow,
                MoveRightKeyInput = KeyCode.RightArrow,
                MoveSpeed = 5f,
            };

            //지금 이벤트가 중복해서 실행이 된다는 문제가 있음
            moveEvent.Execute(this, data);
        }

        private void StopMoving()
        {
            //이거 아니면 그냥 EventBase의 Stop함수 호출
            StopEventCoroutine(EventId.Event_MoveWithTransform);
            //moveEvent.Stop();
        }
    }
}