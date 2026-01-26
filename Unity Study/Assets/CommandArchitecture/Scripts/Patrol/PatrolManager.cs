using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandArchitecture
{
    public class PatrolManager : ObjectBase
    {
        private Dictionary<int, Patrol> patrolDictionary = null;


        public void Init()
        {
            Patrol[] patrolArray = GetComponentsInChildren<Patrol>();

            foreach (var patrol in patrolArray)
            {
                patrol.Init();
            }

            patrolDictionary = patrolArray.ToDictionary(patrol => patrol.GetId(), patrol => patrol);
        }

        public void OnPatrolInteracted(int _id)
        {
            if (patrolDictionary.ContainsKey(_id))
            {
                patrolDictionary[_id].OnPatrolInteracted();
            }
        }

        public void ExecutePatrolAction(int _id)
        {
            if (patrolDictionary.ContainsKey(_id))
            {
                patrolDictionary[_id].ExecutePatrolAction();
            }
        }

        public void OnPatrolAccessDenied(int _id)
        {
            if (patrolDictionary.ContainsKey(_id))
            {
                patrolDictionary[_id].OnPatrolDenied();
            }
        }
    }
}