using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
   [SerializeField]
   private Text _text;
   public Player Player{get; private set;}

   public void SetPlayerInfo(Player player){
      
        Player=player;
        SetPlayerText(player);
        
      }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(targetPlayer!= null && targetPlayer == Player)
          if(changedProps.ContainsKey("IsReady"))
            SetPlayerText(targetPlayer);

    }
    private void SetPlayerText(Player player){

      string isReady="\t";
      if(PhotonNetwork.MasterClient.NickName== player.NickName)
          isReady="M\t";
      else if(player.CustomProperties.ContainsKey("IsReady"))
          isReady=((bool)player.CustomProperties["IsReady"])?"R\t":"\t";
        

      _text.text=isReady+player.NickName;

    }

}
