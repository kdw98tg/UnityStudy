using System;
using UnityEngine;

namespace ObjectManager1
{
    public class Trigger_LightOff : TriggerBase
    {
        public override void Init()
        {
            base.Init();

            onTriggerEnteredCallback = () =>
            {
                CommandInvoker<DoActionParam>.Execute(new DoActionParam()
                {
                    ObjectId = ObjectId.Object_Light,
                    EventId = EventId.Event_SetLightIntensity,
                });
            };
        }
        protected override void OnTriggerEnter(Collider _other)
        {
            base.OnTriggerEnter(_other);
        }
    }
}