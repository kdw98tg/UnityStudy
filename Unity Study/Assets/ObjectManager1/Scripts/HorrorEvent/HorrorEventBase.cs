using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectManager1
{
    public class HorrorEventBase : ObjectBase
    {
        protected Queue<EventObject> eventQueue = null;

        protected virtual void Awake()
        {
            eventQueue = new Queue<EventObject>();
        }
    }

    public class EventObject
    {
        public int ObjectId { get; set; }
        public int EventId { get; set; }
        public Action OnEventEndCallback { get; set; }
    }
}