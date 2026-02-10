using System;
using Unity.VisualScripting;
using UnityEngine;
namespace ObjectManager1
{

    //궁금한 점
    //호러이벤트 객체에서 이닛을 하려고 하니까 좀 이상한게 있음
    //1. 모든 변수들이 호러 이벤트에 모이게 됨
    //2. 호러 이벤트가 너무 비대해짐
    //3. 호러 이벤트가 호출할 객체의 구조를 너무 잘 알게됨 (컴포넌트 구조라던지 오브젝트의 구조라던지)
    //4. ObjectBase는 결국 껍데기정도의 역할이고 거기에 로직을 부여해주는 것은 호러 이벤트임
    //5. 확장성은 굉장히 좋아보이나, 유지보수성엥서 이점이 있는지 모르겠음
    //6. 그리고, 오브젝트가 행동을 끝냈음을 알리는 콜백이 이벤트 객체에 있어야 할거 같음

    //그래서, 각 오브젝트에 각 기능들을 구현한 다음
    // DoAction만 호출하는데, Enum 이나 String으로 분기를 나누는게 어떤가 싶음

    //EventManager가 있고, 거기에 로직들이 들어가 있고 거기서 이제 오브젝트랑 연결해주는 느낌
    //오브젝트 자체의 타입을 나눠서 처리하는게 편함
    //이벤트들을 배치하면 됨
    //이벤트들을 연결해서 순서만 정해주면 됨
    //이벤트 목록들을 만들어서 분류해보기
    //어떤행동, 어떤 정보가 필요한지

    // 2. 이벤트 객체의 큐 혹은 리스트 등 오브젝트들의 이벤트를 관리하는 것은 호출객체라고 생각합니다.
    // 만일 순서대로 진행되어야 한다면 하나의 큐나 리스트로, 병렬로 진행된다면 다수의 큐나 리스트로 관리하도록 해야할 것 같습니다.
    // 강사님이 말씀하셨던 오브젝트 매니저를 사용할 때의 호출객체가 위와 같이 호출할 오브젝트들의 모든 이벤트들을 관리하는지 혹은 다른점이 있는지 궁금합니다.

    // 3. 플레이어와 상호작용을 통해 스스로 동작하는 객체가 대표적으로 문(door) 객체들이 있습니다.
    // 문 객체들은 현재 SlideDoor나 SwingDoor를 상속받습니다.
    // 이 클래스들은 다시 DoorBase를 상속받습니다.
    // 이 부모클래스들은 문을 열거나 닫았을 때 대부분 따로 콜백을 던지지 않고 문이 열리고 닫히는 기능들을 가지고있습니다.
    // 이 문들을 오브젝트 매니저가 관리하는 오브젝트 객체로 변환하기 위해서는 DoorBase가 ObjectBase를 상속받아야 합니다.
    // 외부에서 시키는 일이 있으면 ObjectManager를 통해 해당 이벤트를 수행하고 그렇지 않고 플레이어와 상호작용을 수행할때는 SwingDoor나 SlideDoor에 구현되어있는 기능을 수행하도록 하는 것이 맞는 것 같습니다.
    // 이게 강사님이 말씀하신 오브젝트 매니저가 관리하는 오브젝트의 개념과 부합하는지 궁금합니다.
    // door라고 따로 만들 필요가 없느거임

    public class GameManager : MonoBehaviour
    {
        private ObjectManager objectManager = null;
        private EventManager eventManager = null;
        private TriggerManager tirggerManager = null;
        private HorrorEventManager horrorEventManager = null;
        private PlayerManager playerManager = null;
        private InputManager inputManager = null;


        private void Awake()
        {
            objectManager = GetComponentInChildren<ObjectManager>();
            eventManager = GetComponentInChildren<EventManager>();
            tirggerManager = GetComponentInChildren<TriggerManager>();
            horrorEventManager = GetComponentInChildren<HorrorEventManager>();
            playerManager = GetComponentInChildren<PlayerManager>();
            inputManager = GetComponentInChildren<InputManager>();
        }

        private void Start()
        {
            InitCommands();

            eventManager.Init();
            objectManager.Init();
            tirggerManager.Init();
            horrorEventManager.Init();
            playerManager.Init();
            inputManager.Init();

        }

        private void DoAction(DoActionParam _param)
        {
            var eventBase = eventManager.GetEvent(_param.EventId);
            objectManager.DoAction(_param.ObjectId, eventBase, _param.EventData);
        }

        private void MovePlayer(MovePlayerParam _param)
        {
            playerManager.MovePlayer(_param.ObjectId, _param.MoveDirection);
        }

        private void InitCommands()
        {
            CommandInvoker<DoActionParam>.Add(new Command_DoAction(DoAction));
            CommandInvoker<MovePlayerParam>.Add(new Command_MovePlayer(MovePlayer));
        }
    }
}