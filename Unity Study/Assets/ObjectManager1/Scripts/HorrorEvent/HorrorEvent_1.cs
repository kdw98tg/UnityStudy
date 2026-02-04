using UnityEngine;

namespace ObjectManager1
{
    public class HorrorEvent_1 : HorrorEventBase
    {
        //호러 이벤트 1번 객체는 
        //1. 스위치를 누르면
        //2. 불이 꺼짐
        //3. 불이 꺼지면 호러 이벤트 수행 완료
        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.HorrorEvent_1;

            //스위치 이벤트 실행
            eventQueue.Enqueue(new EventObject()
            {
                ObjectId = (int)ObjectId.Object_LightSwitch,
            });

            //불이 꺼지는 이벤트 실행
            eventQueue.Enqueue(new EventObject()
            {
                ObjectId = (int)ObjectId.Object_Light
            });
        }

        //실제로는 트리거나 특정 이벤트가 될 것임
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DoNext();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                DoNext();
            }
        }

        private void DoNext()
        {
            if (eventQueue.Count > 0)
            {
                var eventObject = eventQueue.Dequeue();
                ObjectManager.GetObjectById((ObjectId)eventObject.ObjectId).DoAction();
            }
            else
            {
                Debug.Log("호러 이벤트 종료");
            }
        }

        private void TurnOffLight(ObjectBase _obj)
        {

        }
    }
}