using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private Text _readyOrPlay;
    private void Awake() {
        _readyOrPlay.text=(PhotonNetwork.IsMasterClient)?"Play":"Ready";
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log(PhotonNetwork.GetPing());
        GetCurrentRoomPlayers();
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _listings.Count; i++)
        {
            Destroy(_listings[i].gameObject);
        }
        _listings.Clear();
    }
    public void FirstInitialize(RoomsCanvases canvases){
        _roomsCanvases=canvases;
    }
    public override void OnLeftRoom()
    {
        _content.DestroyChildren();
        _listings.Clear();
    }
    private void GetCurrentRoomPlayers(){
        if(!PhotonNetwork.IsConnected) return;
        if(PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players==null) return;

        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players){
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player){
                int index = _listings.FindIndex(x=> x.Player==player);
                if(index !=-1){
                    _listings[index].SetPlayerInfo(player);
                }else{
                    PlayerListing listing = Instantiate(_playerListing,_content);
                    if(listing != null){
                        listing.SetPlayerInfo( player);
                        _listings.Add(listing);
                }
                }
                
        
           
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvases.LeaveRoomMenu.OnClick_LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        
        int index = _listings.FindIndex(x=> x.Player== otherPlayer);
                if(index != -1){
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
    }
    public void OnClick_StartGame(){
        if(PhotonNetwork.IsMasterClient ){
            foreach(Player otherPlayer in PhotonNetwork.PlayerListOthers){
                if(!otherPlayer.CustomProperties.ContainsKey("IsReady") || !(bool)otherPlayer.CustomProperties["IsReady"]) return;
            }
            //PhotonNetwork.CurrentRoom.IsOpen=false;
            //PhotonNetwork.CurrentRoom.IsVisible=false;
            foreach(Player otherPlayer in PhotonNetwork.PlayerListOthers){
                if(otherPlayer.CustomProperties.ContainsKey("IsReady"))
                    otherPlayer.CustomProperties.Remove("IsReady");

            }
            PhotonNetwork.LoadLevel(1);
        }else{
            SetReady();
        }
    }
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    public void SetReady(){
        _myCustomProperties["IsReady"] = (_myCustomProperties.ContainsKey("IsReady"))?!(bool)_myCustomProperties["IsReady"]:true;
        PhotonNetwork.LocalPlayer.SetCustomProperties(_myCustomProperties);
    }

    public void OnClick_Ready(){
        if(!PhotonNetwork.IsMasterClient)
            SetReady();
    }
}
