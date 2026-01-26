using System;

namespace CallbackArchitecture
{
    public class HorrorEvent02 : HorrorEvent
    {
public override void Init(Action<int> _onHorrorEventCleared)
        {
            base.Init(_onHorrorEventCleared);
            id = (int)HorrorEventId.HorrorEvent02;
        }
    }
}