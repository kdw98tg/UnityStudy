using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

// public class Launcher : MonoBehaviour
public class Launcher : MonoBehaviourPunCallbacks // 각종 Photon 인터페이스들이 virtual 메서드로 구현되어 있는 클래스 
{
    #region Private SerializeFields
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    private GameObject controlPanel;

    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private GameObject progressLabel;
    #endregion

    #region Private Fields

    //이 클라이언트의 버전 번호임
    //gameVersion이 다르면 서로 다른 그룹으로 분리됨(하위 호환성이 깨지는 변경을 할 때 유용)
    private string gameVersion = "1";
    private bool isConnecting = false;

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

        //방을 들어갔다가 나왔는데 원치않은 매칭이 계속 일어남        
        if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    // #중요: 먼저 기존에 생성된 룸이 있는지 랜덤 룸 참가를 시도합니다.
    // 룸이 존재하면 그대로 참가하고, 없으면 OnJoinRandomFailed() 콜백이 호출됩니다.
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        // #Critical: We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Room for 1' ");

            // #Critical
            // Load the Room Level.
            PhotonNetwork.LoadLevel("Room for 1");
        }
    }
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        //중요함
        //마스터 클라이언트에서 PhotonNetwork.LoadLevel()을 호출하면 
        //같은 룸에 있는 모든 클라이언트가 자동으로 동일한 씬을 로드하도록 동기화 함
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        // Connect();
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    #endregion

    #region Public Method

    /// <summary>
    /// 연결 프로세스를 시작함
    /// 이미 연결되어 있으면 랜덤 룸 참가 시도
    /// 아직 연결되지 않았다면 Photon Cloud 서버에 연결
    /// </summary>
    public void Connect()
    {
        isConnecting = true;

        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
        //현재 연결 상태인지 확인
        //연결되어 있으면 룸에 참가, 아니면 서버에 연결 시작
        if (PhotonNetwork.IsConnected)
        {
            //중요
            //랜덤 룸 참가를 시도함
            //실패하면 OnJoinRandomFailed() 가 호출됨, 그 안에서 룸을 생성함
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //중요
            //가장 먼저 Photon 온라인 서버에 연결해야 함
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion

}
