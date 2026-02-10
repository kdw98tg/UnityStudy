using UnityEngine;

namespace ObjectManager1
{
    public class Player : MonoBehaviour
    {
        private EventBase moveEvent = null;
        private EventBase raycastEvent = null;

        private EventData_MoveWithTransform moveEventData = null;
        private EventData_Raycast raycastEventData = null;

        [SerializeField] private float speed = 1f;


        private void Awake()
        {
            moveEventData = new EventData_MoveWithTransform();
            raycastEventData = new EventData_Raycast();
        }

        public void Init()
        {

        }

        private void Update()
        {
            CheckRayCast();
        }

        private void CheckRayCast()
        {
            raycastEventData.OnRaycastSuccessed = OnRayCastSuccessed;
            raycastEventData.MaxDistance = 10f;
            raycastEventData.DrawDebugRay = true;

            CommandInvoker<DoActionParam>.Execute(new DoActionParam
            {
                ObjectId = ObjectId.Player,
                EventId = EventId.Event_Raycast,
                EventData = raycastEventData
            });
        }

        private void OnRayCastSuccessed(RaycastHit _hit)
        {
            Debug.Log(_hit.transform.name);
        }

        public void Move(ObjectId objectId, Vector3 moveDirection)
        {
            moveEventData.Direction = moveDirection;
            moveEventData.Speed = speed;

            CommandInvoker<DoActionParam>.Execute(new DoActionParam
            {
                ObjectId = objectId,
                EventId = EventId.Event_MoveWithTransform,
                EventData = moveEventData,
            });
        }
    }
}