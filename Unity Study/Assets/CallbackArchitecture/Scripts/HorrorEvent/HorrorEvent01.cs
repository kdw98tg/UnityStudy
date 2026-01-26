using System.Data.Common;

namespace CallbackArchitecture
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