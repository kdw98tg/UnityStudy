using System;
using UnityEngine;

namespace ObjectManager1
{
    public class EventData_SetLightIntensity : EventDataBase
    {
        public float Intensity { get; set; }
        public Action OnActionCompleted { get; set; }
    }
}