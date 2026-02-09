using System.Collections;
using UnityEngine;

namespace ObjectManager1
{
    public abstract class CoroutineEventBase : EventBase
    {
        public abstract IEnumerator ExecuteCoroutineEvent(ObjectBase _base);
    }
}