using System;
using UnityEngine;

namespace CommandArchitecture
{
    public class HorrorEvent : ObjectBase
    {
        protected int id = (int)HorrorEventId.None;

        public virtual void Init()
        {

        }

        public int GetId()
        {
            return id;
        }

        public virtual void OnHorrorEventTriggered()
        {
            Debug.Log($"OnHorrorEventTriggered::{this.transform.name}");

            //일단 조건 없이 바로 클리어
            OnHorrorEventCleared();
        }

        public virtual void OnHorrorEventCleared()
        {
            Debug.Log($"OnHorrorEventCleared::{this.transform.name}");

            CommandInvoker<OnHorrorEventClearedParam>.Execute(new OnHorrorEventClearedParam()
            {
                HorrorEventId = id,
            });
        }
    }

    public enum HorrorEventId
    {
        None,
        HorrorEvent01,
        HorrorEvent02,
        HorrorEvent03,
    }
}