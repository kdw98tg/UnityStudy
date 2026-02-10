using UnityEngine;

namespace ObjectManager1
{
    public class EventData_MoveWithTransform : EventDataBase
    {
        public  Vector3 Direction { get; set; }
        public  float Speed { get; set; }
    }
}