using System;
using UnityEngine;

namespace CallbackArchitecture
{
    public class PatrolCondition : ObjectBase
    {
        protected int id = (int)PatrolConditionId.None;

        protected bool isCleared = false;
        
        public virtual void Init()
        {

        }

        public int GetId()
        {
            return id;
        }

        public virtual void OnPatrolConditionCompleted()
        {
            isCleared = true;
        }

        public virtual bool HasCleared()
        {
            return isCleared;
        }

        public virtual void UpdateProgress(int horrorEventId)
        {
            Debug.Log($"UpdateProgress::{transform.name}");
        }
    }
}