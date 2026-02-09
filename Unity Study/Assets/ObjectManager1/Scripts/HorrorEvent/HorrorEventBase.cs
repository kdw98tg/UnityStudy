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
        public ObjectId ObjectId { get; set; }
        public EventId EventId { get; set; }
        public EventDataBase EventData { get; set; }
        public Action OnEventEndCallback { get; set; }
    }
}