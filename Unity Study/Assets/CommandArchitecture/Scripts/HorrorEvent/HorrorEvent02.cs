using System;

namespace CommandArchitecture
{
    public class HorrorEvent02 : HorrorEvent
    {
        public override void Init()
        {
            base.Init();
            id = (int)HorrorEventId.HorrorEvent02;
        }
    }
}