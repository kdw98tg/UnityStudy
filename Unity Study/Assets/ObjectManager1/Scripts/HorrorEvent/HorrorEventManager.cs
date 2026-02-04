using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectManager1
{
    public class HorrorEventManager : MonoBehaviour
    {
        private Dictionary<int, HorrorEventBase> horrorEventDictionary = null;
        private void Awake()
        {
            horrorEventDictionary = new Dictionary<int, HorrorEventBase>();
        }

        public void Init()
        {
            horrorEventDictionary = GetComponentsInChildren<HorrorEventBase>().ToDictionary(horrorEvent => horrorEvent.GetId(), horrorEvent => horrorEvent);
        }
    }
}