using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases){
        _roomsCanvases=canvases;
    }
    public void OnClick_LeaveRoom(){
        PhotonNetwork.LeaveRoom(true);
        if(PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("IsReady"))
            PhotonNetwork.LocalPlayer.CustomProperties["IsReady"]=false;
        _roomsCanvases.CurrentRoomCanvases.Hide();
    }
    
}
