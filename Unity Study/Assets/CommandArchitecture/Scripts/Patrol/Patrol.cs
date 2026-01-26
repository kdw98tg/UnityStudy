using System;
using Unity.VisualScripting;
using UnityEngine;

namespace CommandArchitecture
{
    public class Patrol : ObjectBase
    {
        protected int id = (int)PatrolId.None;

        private Action<int> onPatrolInteracted = null;
        private Action onPatrolDenied = null;
        private Action onExecutePatrolAction = null;

        //호러 이벤트를 트리거 해주는 콜백
        protected Action<int> onHorrorEventTrigger = null;

        public virtual void Init(Action<int> _onPatrolInteracted, Action<int> _onHorrorEventTrigger)
        {
            onPatrolInteracted = _onPatrolInteracted;
            onHorrorEventTrigger = _onHorrorEventTrigger;
        }

        public int GetId()
        {
            return this.id;
        }

        /// <summary>
        /// 패트롤과 상호작용시 발동되는 함수
        /// </summary>
        public virtual void OnPatrolInteracted()
        {
            Debug.Log($"OnPatrolInteracted::{this.transform.name}");
            onPatrolInteracted?.Invoke(id);
        }

        /// <summary>
        /// 패트롤을 찍을 수 없는 상태일 때 실행되는 함수
        /// </summary>
        public virtual void OnPatrolDenied()
        {
            Debug.Log($"OnPatrolDenied::{this.transform.name}");
            onPatrolDenied?.Invoke();
        }

        /// <summary>
        /// 패트롤을 찍을 수 있는 상태에서, 찍혔을 때 할 행동을 정의
        /// </summary>
        public virtual void ExecutePatrolAction()
        {
            Debug.Log($"ExecutePatrolAction::{this.transform.name}");
            onExecutePatrolAction?.Invoke();
        }
    }

    public enum PatrolId
    {
        None,
        Patrol01,
        Patrol02,
        Patrol03,
    }
}