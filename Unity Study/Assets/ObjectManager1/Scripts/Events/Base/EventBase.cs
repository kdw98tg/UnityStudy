using UnityEngine;

namespace ObjectManager1
{
    public abstract class EventBase : MonoBehaviour
    {
        protected EventId id = (int)EventId.None;

        public virtual void Init()
        {

        }

        public abstract void Execute(ObjectBase _objectBase, EventDataBase _data);

        public abstract void Stop();

        public EventId GetId()
        {
            return id;
        }
    }
}