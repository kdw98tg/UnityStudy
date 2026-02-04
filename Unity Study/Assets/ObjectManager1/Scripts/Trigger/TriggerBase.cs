using System;
using UnityEngine;

namespace ObjectManager1
{
    public class TriggerBase : ObjectBase
    {
        protected int id = (int)ObjectId.None;
        protected Action onTriggerEnteredCallback = null;

        public void Init()
        {

        }

        protected virtual void OnTriggerEnter(Collider _other)
        {
            onTriggerEnteredCallback?.Invoke();
        }

        public void SetOnTriggerEnteredCallback(Action _onTriggerEnteredCallback)
        {
            onTriggerEnteredCallback = _onTriggerEnteredCallback;
        }

        public int GetId()
        {
            return id;
        }
    }
}