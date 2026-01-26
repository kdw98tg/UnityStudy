using System;
using System.Collections.Generic;
using System.Linq;

namespace CallbackArchitecture
{
    public class PatrolManager : ObjectBase
    {
        private Action<int> onPatrolInteracted = null;
        private Action<int> onHorrorEventTrigger = null;

        private Dictionary<int, Patrol> patrolDictionary = null;


        public void Init()
        {
            Patrol[] patrolArray = GetComponentsInChildren<Patrol>();

            foreach (var patrol in patrolArray)
            {
                patrol.Init(OnPatrolInteracted, OnHorrorEventTrigger);
            }

            patrolDictionary = patrolArray.ToDictionary(patrol => patrol.GetId(), patrol => patrol);
        }

        public void OnPatrolInteracted(int _id)
        {
            onPatrolInteracted?.Invoke(_id);
        }

        public void OnHorrorEventTrigger(int _id)
        {
            onHorrorEventTrigger?.Invoke(_id);
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