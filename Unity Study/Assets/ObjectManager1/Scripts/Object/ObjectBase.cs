using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace ObjectManager1
{
    public class ObjectBase : MonoBehaviour
    {
        protected int id = (int)ObjectId.None;

        //이벤트 ID별로 코루틴을 관리할 수 있도록 함
        protected Dictionary<EventId, Coroutine> activeCoroutines;

        public virtual void Init()
        {
            activeCoroutines = new Dictionary<EventId, Coroutine>();
        }

        public virtual void DoAction(EventBase _eventBase)
        {

        }

        public void StartEventCoroutine(EventId _eventId, IEnumerator _routine)
        {
            // 같은 이벤트가 이미 실행 중이면 중단
            if (activeCoroutines.ContainsKey(_eventId))
            {
                StopCoroutine(activeCoroutines[_eventId]);
            }
            // 새 코루틴 시작 및 저장
            Coroutine coroutine = StartCoroutine(_routine);
            activeCoroutines[_eventId] = coroutine;
        }

        public void StopEventCoroutine(EventId eventId)
        {
            if (activeCoroutines.ContainsKey(eventId))
            {
                StopCoroutine(activeCoroutines[eventId]);
                activeCoroutines.Remove(eventId);
            }
        }

        // 모든 이벤트 중단
        public void StopAllEventCoroutines()
        {
            foreach (var coroutine in activeCoroutines.Values)
            {
                StopCoroutine(coroutine);
            }
            activeCoroutines.Clear();
        }

        // 특정 이벤트가 실행 중인지 확인
        public bool IsEventRunning(EventId eventId)
        {
            return activeCoroutines.ContainsKey(eventId);
        }

        public int GetId()
        {
            return id;
        }
    }

}