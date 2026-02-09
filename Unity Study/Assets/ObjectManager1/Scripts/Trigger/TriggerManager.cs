using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectManager1
{
    public class TriggerManager : MonoBehaviour
    {
        private Dictionary<int, TriggerBase> triggerDictionary = null;

        public void Init()
        {
            TriggerBase[] triggerBaseArray = GetComponentsInChildren<TriggerBase>();

            foreach (TriggerBase trigger in triggerBaseArray)
            {
                trigger.Init();
            }

            triggerDictionary = triggerBaseArray.ToDictionary(trigger => trigger.GetId(), trigger => trigger);
        }

        public void EnableTrigger(int _triggerId, bool _enabled)
        {
            if (triggerDictionary.ContainsKey(_triggerId))
            {
                triggerDictionary[_triggerId].gameObject.SetActive(_enabled);
            }
        }

        public void SetOnTriggerEnteredCallback(int _triggerId, Action _onTriggerEnteredCallback)
        {
            if (triggerDictionary.ContainsKey(_triggerId))
            {
                triggerDictionary[_triggerId].SetOnTriggerEnteredCallback(_onTriggerEnteredCallback);
            }
        }
    }
}