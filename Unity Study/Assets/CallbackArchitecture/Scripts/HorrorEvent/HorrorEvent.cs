using UnityEngine;
namespace CallbackArchitecture
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
        }

        public virtual void OnHorrorEventCleared()
        {
            Debug.Log($"OnHorrorEventCleared::{this.transform.name}");
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