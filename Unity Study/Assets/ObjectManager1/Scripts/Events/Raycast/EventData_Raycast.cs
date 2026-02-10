using System;
using UnityEngine;

namespace ObjectManager1
{
    public class EventData_Raycast : EventDataBase
    {
        public Action<RaycastHit> OnRaycastSuccessed { get; set; }
        public bool DrawDebugRay { get; set; }
        public float MaxDistance { get; set; }
    }
}