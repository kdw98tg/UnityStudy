using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ObjectManager1
{
    public class MovePlayerParam : IParam
    {
        public ObjectId ObjectId { get; set; }
        public Vector3 MoveDirection { get; set; }
    }
}