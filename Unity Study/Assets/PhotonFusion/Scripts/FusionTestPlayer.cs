using Fusion;
using UnityEngine;
namespace FusionTest
{
    // 이 스크립트를 빈 게임오브젝트에 붙이고 
    // 유니티 메뉴의 [Fusion] -> [Networked Object] 를 붙여서 프리팹화 하세요.
    public class FusionTestPlayer : NetworkBehaviour
    {
        // ==========================================
        // 1. [Networked] 변수들 정의
        // ==========================================

        // 이 프로퍼티는값이 바뀔때 콜백을 받을 수 있습니다. OnHpChanged 참조.
        [Networked, OnChangedRender(nameof(OnHpChanged))]
        public int HP { get; set; }

        [Networked]
        public NetworkBool IsBeatSubmitted { get; set; }

        [Networked, Capacity(5)] // 테스트용으로 크기 5개짜리 배열 선언
        public NetworkArray<float> BeatArray { get; }


        public override void Spawned()
        {
            // 씬에 등장할때 초기 세팅 (서버에서만 수행)
            if (HasStateAuthority)
            {
                HP = 3;
                IsBeatSubmitted = false;
            }
        }

        // ==========================================
        // 2. 디버깅 GUI (핵심: 버튼을 눌러 테스트해보세요!)
        // ==========================================
        private void OnGUI()
        {
            // 내 로컬 화면에만 GUI를 띄웁니다.
            if (!HasInputAuthority) return;

            GUILayout.BeginArea(new Rect(10, 100, 300, 300));
            GUILayout.Label($"[내 캐릭터 정보] ID: {Object.Id}");
            GUILayout.Label($"HP: {HP}");
            GUILayout.Label($"제출 완료 여부: {IsBeatSubmitted}");

            // 내 권한인 경우: 비트 전송 버튼 생성 
            if (GUILayout.Button("1. 서버로 비트 제출하기(RPC)"))
            {
                // 가짜 비트 데이터 3개 전송
                float[] fakeBeats = new float[] { 1.2f, 2.5f, 3.8f };
                RPC_SendBeatToServer(fakeBeats);
            }

            // 호스트(서버)인 경우: 무조건 데미지 주기 (다른사람도 포함) 
            if (HasStateAuthority && GUILayout.Button("2. [Host Only] HP 1 감소시키기"))
            {
                // 놀랍게도 HP-- 한 줄로 모든 클라이언트의 화면에서 HP가 바뀝니다.
                HP--;
            }

            // 배열 잘 들어있나 읽어보기
            if (GUILayout.Button("3. 현재 들고있는 BeatArray 출력"))
            {
                for (int i = 0; i < BeatArray.Length; i++)
                {
                    if (BeatArray[i] > 0)
                        Debug.Log($"Beat[{i}] : {BeatArray[i]}");
                }
            }

            GUILayout.EndArea();
        }


        // ==========================================
        // 3. RPC 및 콜백 함수
        // ==========================================

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
        private void RPC_SendBeatToServer(float[] inputBeats)
        {
            Debug.Log($"서버에 비트 데이터가 도착했습니다! 크기: {inputBeats.Length}");

            // 서버 메모리에 저장!
            for (int i = 0; i < inputBeats.Length && i < BeatArray.Length; i++)
            {
                BeatArray.Set(i, inputBeats[i]);
            }

            // 제출 플래그 ON! 
            IsBeatSubmitted = true;
        }

        // HP 값이 StateAuthority(서버)에 의해 변경되었을 때, 
        // 모든 클라이언트가 이 콜백을 실행하여 로그를 남기거나 애니메이션을 켤 수 있습니다.
        public void OnHpChanged()
        {
            Debug.Log($"[클라이언트 반응] 어라? 내 HP가 {HP} 로 바꼈네!");
            // 여기서 파티클 재생이나 UI 업데이트 등을 하면 됩니다.
        }
    }
}