using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace FusionTest
{
    // 씬에 빈 게임오브젝트 생성 후 이 스크립트를 붙입니다.
    public class FusionTestGameManager : MonoBehaviour, INetworkRunnerCallbacks
    {
        public NetworkPrefabRef playerPrefab; // 인스펙터에서 등록해주세요!
        private NetworkRunner _runner;

        // 테스트용: 화면에 GUI 버튼 만들기
        private void OnGUI()
        {
            if (_runner == null)
            {
                if (GUI.Button(new Rect(10, 10, 200, 50), "Start Auto Host/Client"))
                {
                    StartGame();
                }
            }
        }

        private async void StartGame()
        {
            _runner = gameObject.AddComponent<NetworkRunner>();
            _runner.ProvideInput = true;

            await _runner.StartGame(new StartGameArgs()
            {
                GameMode = GameMode.AutoHostOrClient,
                SessionName = "",
                PlayerCount = 2,
                Scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex),
            });
        }

        // 누군가 방에 들어오면 플레이어 프리팹을 스폰합니다.
        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (runner.IsServer) // 호스트만 스폰 권한이 있습니다
            {
                // (0,0,0) 위치에 플레이어 소환, 해당 플레이어(player)에게 권한(InputAuthority) 부여
                runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity, player);
                Debug.Log($"플레이어 스폰됨: {player}");
            }
        }

        // --- 아래는 필수 구현 인터페이스 (비워둠) ---
        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
        public void OnInput(NetworkRunner runner, NetworkInput input) { }
        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
        public void OnConnectedToServer(NetworkRunner runner) { }
        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }
        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
        public void OnSceneLoadDone(NetworkRunner runner) { }
        public void OnSceneLoadStart(NetworkRunner runner) { }
        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }
        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
    }
}