using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace CallbackArchitecture
{
    public class HorrorEventManager : ObjectBase
    {
        private Dictionary<int, HorrorEvent> horrorEventDictionary = null;
        private Dictionary<int, PatrolFlow> nextPatrolDictionary = null;
        private Action<int> onHorrorEventCleared = null;

        public void Init(Action<int> _onHorrorEventCleared)
        {
            onHorrorEventCleared = _onHorrorEventCleared;

            InitPatrolFlowDictionary();

            HorrorEvent[] horrorEventArray = GetComponentsInChildren<HorrorEvent>();

            foreach (var horrorEvent in horrorEventArray)
            {
                horrorEvent.Init(OnHorrorEventCleaerd);
            }

            horrorEventDictionary = horrorEventArray.ToDictionary(horrorEvent => horrorEvent.GetId(), horrorEvent => horrorEvent);
        }

        private void InitPatrolFlowDictionary()
        {
            nextPatrolDictionary = new Dictionary<int, PatrolFlow>
            {
                { (int)HorrorEventId.HorrorEvent01, new PatrolFlow() { NextPatrolId = (int)PatrolId.Patrol02, NextPatrolConditionId = (int)PatrolConditionId.PatrolCondition02 } },
                { (int)HorrorEventId.HorrorEvent02, new PatrolFlow() { NextPatrolId = (int)PatrolId.Patrol03, NextPatrolConditionId = (int)PatrolConditionId.PatrolCondition03 } }
            };
        }

        public PatrolFlow GetNextPatrolFlow(int _horrorEventId)
        {
            if (nextPatrolDictionary.ContainsKey(_horrorEventId))
            {
                return nextPatrolDictionary[_horrorEventId];
            }
            return default;
        }

        public void OnHorrorEventTrigger(int _id)
        {
            if (horrorEventDictionary.ContainsKey(_id))
            {
                horrorEventDictionary[_id].OnHorrorEventTriggered();
            }
        }

        public void OnHorrorEventCleaerd(int _id)
        {
            onHorrorEventCleared?.Invoke(_id);
        }
    }
}