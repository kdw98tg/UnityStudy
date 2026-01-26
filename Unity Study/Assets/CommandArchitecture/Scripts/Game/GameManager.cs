using UnityEngine;

namespace CommandArchitecture
{
    //이 예제는 Callback 방식으로 구현한 유니티 아키텍쳐의 예제 입니다.
    //각 오브젝트는 콜백으로 자신의 상태를 알려주고, GameManager는 그 콜백들을 받아서 행동을 처리합니다.
    //JustPatrol 게임의 일부를 간단하게 구현합니다.
    //1번 Patol을 찍을 상황이 되면, 1번 Patrol을 찍습니다. (1~3번까지의 숫자로 발동합니다. Log 로만 동작하기 때문에, Input이 애매해질 수 있습니다.)
    //PatrolCondition은 Patrol을 찍을 수 있는지를 검사합니다.
    //HorrorEvent는 특정 공포 기믹이 수행되는 객체입니다. (q, w, e 와 같은 키 입력으로 동작합니다.)

    public class GameManager : MonoBehaviour
    {
        private PatrolManager patrolManager = null;
        private PatrolConditionManager patrolConditionManager = null;
        private HorrorEventManager horrorEventManager = null;

        private void Awake()
        {
            patrolManager = GetComponentInChildren<PatrolManager>();
            patrolConditionManager = GetComponentInChildren<PatrolConditionManager>();
            horrorEventManager = GetComponentInChildren<HorrorEventManager>();
        }

        private void Start()
        {
            patrolManager.Init(OnPatrolInteracted);
            patrolConditionManager.Init();
            horrorEventManager.Init(OnHorrorEventCleared);

            //제일 처음 Patrol을 가능하게 하기 위한 코드
            patrolConditionManager.UpdatePatrolCondition(1, 0);

            InitCommands();
            CommandInvoker<OnHorrorEventTriggerParam>.Execute(new OnHorrorEventTriggerParam() { });
        }

        //TEMP 
        //실제로 찍는거 대신에 인풋으로 조작하기 위해서 임시로 만듦
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                patrolManager.OnPatrolInteracted((int)PatrolId.Patrol01);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                patrolManager.OnPatrolInteracted((int)PatrolId.Patrol02);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                patrolManager.OnPatrolInteracted((int)PatrolId.Patrol03);
        }

        private void InitCommands()
        {
            CommandInvoker<OnHorrorEventTriggerParam>.Add(new GameCommand_OnHorrorEventTrigger(OnHorrorEventTrigger));
        }

        //패트롤이 찍힐 때 호출
        private void OnPatrolInteracted(int _id)
        {
            //patrolCondition 에서 조건이 완료 되었다면 패트롤의 행동을 수행
            //patrolCondition 에서 조건이 완료되지 않았다면, 패트롤이 거부될때의 행동을 수행
            if (patrolConditionManager.HasPatrolConditionCompleted(_id))
            {
                patrolManager.ExecutePatrolAction(_id);
            }
            else
            {
                patrolManager.OnPatrolAccessDenied(_id);
            }
        }

        //호러 이벤트가 트리거 될 때, 호출
        private void OnHorrorEventTrigger(OnHorrorEventTriggerParam _param)
        {
            Debug.Log("123");
            horrorEventManager.OnHorrorEventTrigger(_param.Id);
        }

        //호러 이벤트가 끝났을 때, 처리
        private void OnHorrorEventCleared(int _horrorEventId)
        {
            PatrolFlow patrolFlow = horrorEventManager.GetNextPatrolFlow(_horrorEventId);
            patrolConditionManager.UpdatePatrolCondition(patrolFlow.NextPatrolConditionId, _horrorEventId);
        }
    }
}