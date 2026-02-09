using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

namespace ObjectManager1
{
    public class ObjectBase : MonoBehaviour
    {
        protected int id = (int)ObjectId.None;

        //이벤트 ID별로 코루틴을 관리할 수 있도록 함
        protected Dictionary<EventId, Coroutine> activeCoroutines;

        //오브젝트의 컴포넌트를 담당하는 딕셔너리 (Event에 넣어주기 위해서)
        protected Dictionary<Type, Component> cachedComponentDictionray = new Dictionary<Type, Component>();

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

        //컴포넌트를 가져올때 마다 GetComponent 하는게 아니라, 딕셔너리로 관리하면서 캐싱된걸 가져오는 역할
        //캐싱된 컴포넌트는 오브젝트가 파괴되거나, disabled 되면, 저장된 캐시는 날려버려야 할듯
        public T GetCachedComponent<T>() where T : Component
        {
            var type = typeof(T);

            // 1. 이미 캐시에 있나? -> 있으면 바로 줌
            if (cachedComponentDictionray.ContainsKey(type))
                return (T)cachedComponentDictionray[type];

            // 2. 없나? -> GetComponent로 찾아서 캐시에 등록하고 줌
            var component = GetComponent<T>();
            if (component != null)
            {
                cachedComponentDictionray.Add(type, component);
                return component;
            }
            else
            {
                component = GetComponentInChildren<T>();
                if (component != null)
                {
                    cachedComponentDictionray.Add(type, component);
                }
                return component;
            }
        }

        public int GetId()
        {
            return id;
        }

        private void OnDestroy()
        {
            cachedComponentDictionray.Clear();
        }
    }

}