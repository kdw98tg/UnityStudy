using System.Collections;

using UnityEngine;

// 공포게임은 이벤트로서 게임이 돌아가기 때문에 
// 이런식으로 관리하는게 좋음
// 근데 mmo prg 같은거는 좀 힘듦
// 전통적인 oop로 가는게 좋음

namespace ObjectManager1
{
    public class HorrorEvent_1 : HorrorEventBase
    {
        //rpg 같은거는 object 를 관리하는게 아니라
        //하는일이 아니고 이제 객체별로 관리하면됨
        //questManager, characterManager 등등
        //component 랑은 개념이 살짝 다른게, 동작 모음이랑 기능 모음이랑 다름
        //지금은 동작 모음 느낌

        //총쏘는게임은 음악 노트처리
        //이벤트로 관리할게 많이 없음

        public override void Init()
        {
            base.Init();
            id = (int)ObjectId.HorrorEvent_1;
        }

        //TEMP
        //나중에는 Trigger나 레이케스트 상호작용등이 될것임
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
                TriggerEvent();
        }

        // 트리거가 호출하면 이벤트 시작
        public void TriggerEvent()
        {
            StartCoroutine(ExecuteEventSequence());
        }

//이벤트를 관리하는게 

        private IEnumerator ExecuteEventSequence()
        {
            // 2. 불이 꺼짐
            CommandInvoker<DoActionParam>.Execute(new DoActionParam
            {
                ObjectId = ObjectId.Object_Light,
                EventId = EventId.Event_SetLightIntensity,
                EventData = new EventData_SetLightIntensity { Intensity = 0f }
            });

            yield return new WaitForSeconds(0.5f);//쉬었다도 이벤트로 만들어줘야 함 -> 그래야 이벤트만으로 관리가 됨

            CommandInvoker<DoActionParam>.Execute(new DoActionParam
            {
                ObjectId = ObjectId.Object_Light,
                EventId = EventId.Event_SetLightIntensity,
                EventData = new EventData_SetLightIntensity { Intensity = 10f }
            });

            Debug.Log("Horror Event 1 Complete!");
        }
    }

    // public class HorrorEvent_1 : HorrorEventBase
    // {
    //     //호러 이벤트 1번 객체는 
    //     //1. 스위치를 누르면
    //     //2. 불이 꺼짐
    //     //3. 불이 꺼지면 호러 이벤트 수행 완료
    //     public override void Init()
    //     {
    //         base.Init();
    //         id = (int)ObjectId.HorrorEvent_1;
    //     }

    //     //실제로는 트리거나 특정 이벤트가 될 것임
    //     private void Update()
    //     {
    //         // 트리거가 밟히면
    //         if (Input.GetKeyDown(KeyCode.U))
    //         {
    //             DoNext();
    //         }

    //         // 어떤 이벤트를 실행하고
    //         //1. DoAction 커맨드 던지면 됨

    //         // 어떤 이벤트 실행중에 어떤 상태가 되면 완료 콜백을 받아야 함
    //         //1. 어떤 이벤트 실행중에 어떤 값이 되면, 콜백 함수를 호출해야함
    //         //2. 콜백 함수는 호출이 되면, 자신을 호출시킨 호러이벤트로 와서 작업을 해야함
    //         //3. 그러면 오브젝트 입장에서? 아니면 이벤트 입장에서 어떤 상황에서 Invoke() 해줘야 함


    //         // 그러면 얘 입장에서는 다음 이벤트드를 실행해줘야 함
    //         // 얘는 콜백을 받아서 어떤 이벤트로 넘어갈지 정해주면 끝
    //     }

    //     //그냥 코루틴을 돌려도 되려나?
    //     //어차피 선형적인 이벤트는 거의 없고
    //     //트리거나 이런거 밟았을때 뭐가 벌어지는데 
    //     //WaitFor... 이런걸로 어떻게 될수도 있겠네
    //     private void DoNext()
    //     {
    //         //결국 여기서 이벤트를 찾아줘야하나?
    //         //찾아주지 않는다고 하더라도 여기서 필요한 파라미터는 여기서 만들어서 넣어줘야 할 것 같긴 함


    //     }
    // }
}