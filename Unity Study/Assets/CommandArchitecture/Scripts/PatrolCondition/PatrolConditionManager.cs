using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandArchitecture
{
    public class PatrolConditionManager : ObjectBase
    {
        private Dictionary<int, PatrolCondition> patrolConditionDictionary = null;
        public void Init()
        {
            PatrolCondition[] patrolConditionArray = GetComponentsInChildren<PatrolCondition>();

            foreach (var patrolCondition in patrolConditionArray)
            {
                patrolCondition.Init();
            }

            patrolConditionDictionary = patrolConditionArray.ToDictionary(patrolCondition => patrolCondition.GetId(), patrolCondition => patrolCondition);
        }

        public bool HasPatrolConditionCompleted(int _id)
        {
            bool result = false;
            if (patrolConditionDictionary.ContainsKey(_id))
            {
                result = patrolConditionDictionary[_id].HasCleared();
            }
            return result;
        }

        public void UpdatePatrolCondition(int _patrolConditionId,int _horrorEventId)
        {
            if (patrolConditionDictionary.ContainsKey(_patrolConditionId))
            {
                patrolConditionDictionary[_patrolConditionId].UpdateProgress(_horrorEventId);
            }
        }
    }

    public enum PatrolConditionId
    {
        None,
        PatrolCondition01,
        PatrolCondition02,
        PatrolCondition03,
    }
}