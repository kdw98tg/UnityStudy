using System;
using System.Data.Common;

namespace CommandArchitecture
{
    public class HorrorEvent01 : HorrorEvent
    {
        public override void Init()
        {
            base.Init();
            id = (int)HorrorEventId.HorrorEvent01;
        }
    }
}