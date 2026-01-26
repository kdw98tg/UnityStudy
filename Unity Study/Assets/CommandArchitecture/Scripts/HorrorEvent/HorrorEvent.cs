using System;
using UnityEngine;

namespace CommandArchitecture
{
    public class HorrorEvent : ObjectBase
    {
        protected int id = (int)HorrorEventId.None;
        private Action<int> onHorrorEventCleared = null;

        public virtual void Init(Action<int> _onHorrorEventCleared)
        {
            onHorrorEventCleared = _onHorrorEventCleared;
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
            onHorrorEventCleared?.Invoke(id);
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