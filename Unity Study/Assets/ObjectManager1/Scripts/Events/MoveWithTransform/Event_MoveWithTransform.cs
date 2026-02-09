using System.Collections;
using UnityEngine;

namespace ObjectManager1
{
    public class Event_MoveWithTransform : EventBase
    {
        public override void Init()
        {
            base.Init();
            id = EventId.Event_MoveWithTransform;
        }

        public override void Execute(ObjectBase _objectBase, EventDataBase _data)
        {
            _objectBase.StartEventCoroutine(EventId.Event_MoveWithTransform, CoMove(_objectBase, _data));
        }

        private IEnumerator CoMove(ObjectBase _objectBase, EventDataBase _data)
        {
            var data = _data as EventData_MoveWithTransform;

            float moveSpeed = data.MoveSpeed;

            while (true)
            {
                if (Input.GetKeyDown(data.MoveForwardKeyInput))
                {
                    _objectBase.transform.position += new Vector3(0f, 0f, moveSpeed);
                }
                if (Input.GetKeyDown(data.MoveLeftKeyInput))
                {
                    _objectBase.transform.position += new Vector3(-moveSpeed, 0f, 0f);
                }
                if (Input.GetKeyDown(data.MoveBackKeyInput))
                {
                    _objectBase.transform.position += new Vector3(0f, 0f, -moveSpeed);
                }
                if (Input.GetKeyDown(data.MoveRightKeyInput))
                {
                    _objectBase.transform.position += new Vector3(moveSpeed, 0f, 0f);
                }

                yield return null;
            }
        }

        public override void Stop()
        {

        }
    }
}