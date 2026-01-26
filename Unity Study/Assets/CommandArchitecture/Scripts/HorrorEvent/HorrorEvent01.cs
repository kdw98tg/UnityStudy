using System;
using System.Data.Common;

namespace CommandArchitecture
{
    public class HorrorEvent01 : HorrorEvent
    {
        public override void Init(Action<int> _onHorrorEventCleared)
        {
            base.Init(_onHorrorEventCleared);
            id = (int)HorrorEventId.HorrorEvent01;
        }
    }
}