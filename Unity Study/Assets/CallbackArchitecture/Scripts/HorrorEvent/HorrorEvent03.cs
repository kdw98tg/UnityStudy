using System;

namespace CallbackArchitecture
{
    public class HorrorEvent03 : HorrorEvent
    {
        public override void Init(Action<int> _onHorrorEventCleared)
        {
            base.Init(_onHorrorEventCleared);
            id = (int)HorrorEventId.HorrorEvent03;
        }
    }
}