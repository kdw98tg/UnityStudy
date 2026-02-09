using System;
using UnityEngine;

namespace ObjectManager1
{
    public class TriggerBase : ObjectBase
    {
        protected Action onTriggerEnteredCallback = null;
        protected Action onTriggerExitedCallback = null;

        protected virtual void OnTriggerEnter(Collider _other)
        {
            onTriggerEnteredCallback?.Invoke();
        }

        protected virtual void OnTriggerExit(Collider _other)
        {
            onTriggerExitedCallback?.Invoke();
        }

        public void SetOnTriggerEnteredCallback(Action _onTriggerEnteredCallback)
        {
            onTriggerEnteredCallback = _onTriggerEnteredCallback;
        }
        
        public void SetOnTriggerExitedCallback(Action _onTriggerExitedCallback)
        {
            onTriggerExitedCallback = _onTriggerExitedCallback;
        }
    }
}