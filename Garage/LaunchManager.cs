using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    byte maxPlayerPerRoom = 8;
    bool isConnecting;
    public InputField playerName;
    public Text feedbackText;
    string gameVersion = "1";

    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
        if(PlayerPrefs.HasKey("PlayerName"))
            playerName.text = PlayerPrefs.GetString("PlayerName");
    }

    public void ConnectNetwork(){
        feedbackText.text = "";
        isConnecting = true;
        PhotonNetwork.NickName = playerName.text;
        if(PhotonNetwork.IsConnected){
            feedbackText.text +="\nJoining Room...";
            PhotonNetwork.JoinRandomRoom();
        }else{
            feedbackText.text += "\nConnecting";
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    void Start()
    {
        
    }

    //Network callbacks
    public override void OnConnectedToMaster()
    {
        if(isConnecting){
            feedbackText.text += "\nOnConnectedMaster";
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        feedbackText.text += "\nFailed to join random room";
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = this.maxPlayerPerRoom});
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        feedbackText.text += "\nDisconnected because" + cause;
        isConnecting = false;
    }

    public override void OnJoinedRoom()
    {
        feedbackText.text += "\nJoined room with " + PhotonNetwork.CurrentRoom.PlayerCount + "players.";
        //PhotonNetwork.LoadLevel("TestScene");
    }































































































































































































   
}
