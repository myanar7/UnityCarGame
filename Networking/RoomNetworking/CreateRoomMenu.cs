using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialized(RoomsCanvases canvases) {
        _roomsCanvases=canvases;
    }


    public void OnClick_CreateRoom(){
        
        if(!PhotonNetwork.IsConnected) return;

        RoomOptions roomOptions= new RoomOptions();
        roomOptions.BroadcastPropsChangeToAll=true;
        roomOptions.MaxPlayers=4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text,roomOptions,TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Successfully.");
        _roomsCanvases.CurrentRoomCanvases.Show();
        Debug.Log(PhotonNetwork.PlayerList[0].NickName);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room Failed");
    }
}
