using UnityEngine;

namespace ObjectManager1
{
    public class EventData_MoveWithTransform : EventDataBase
    {
        public KeyCode MoveForwardKeyInput { get; set; }
        public KeyCode MoveBackKeyInput { get; set; }
        public KeyCode MoveLeftKeyInput { get; set; }
        public KeyCode MoveRightKeyInput { get; set; }
        public float MoveSpeed { get; set; }
    }
}