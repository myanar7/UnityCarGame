using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
   [SerializeField]
   private Text _text;
   public RoomInfo RoomInfo{get; private set;}

   public void SetRoomInfo(RoomInfo roomInfo){
       RoomInfo=roomInfo;
       _text.text=roomInfo.Name+"\t"+roomInfo.PlayerCount+"/"+roomInfo.MaxPlayers;
   }
   public void onClick_Join(){
       PhotonNetwork.JoinRoom(RoomInfo.Name);
   }
}
