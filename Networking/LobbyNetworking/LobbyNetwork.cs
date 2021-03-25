using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion= MasterManager.GameSettings.GameVersion;
        PhotonNetwork.SerializationRate=30;
        Debug.Log("Connecting to server");
        PhotonNetwork.AutomaticallySyncScene=true;
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster() {
        Debug.Log("Connected to server");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        if(!PhotonNetwork.InLobby){
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for reason "+cause.ToString());
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to the lobby");
    }
    



    
}
