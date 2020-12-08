using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby: MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now conneceted to the " + PhotonNetwork.CloudRegion + "server!");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);

    }

    public void OnBattleButtonClicked()
    {
        Debug.Log("Battle Button was clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a ramdom game but failed. There must be no open games available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create new room");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSetting.multiplayerSetting.maxPlayer};
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in a room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create new room but failed, there must already be a room with the same name.");
        OnCreatedRoom();
    }
    public void OncancelButtonClicked()
    {
        Debug.Log("");
            cancelButton.SetActive(false);
            cancelButton.SetActive(true);
            PhotonNetwork.LeaveRoom();
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
