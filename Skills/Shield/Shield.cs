using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Shield : MonoBehaviourPun
{
    [PunRPC]
    public void RPC_SetParent(string playerName){
        gameObject.transform.SetParent(GameObject.Find(playerName).transform);
        gameObject.transform.Rotate(new Vector3(90,0,0));
    }

}
