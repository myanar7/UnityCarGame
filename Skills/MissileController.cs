using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MissileController : MonoBehaviourPun
{
    public Transform missileSpawnPoint;
    public Transform mineSpawnPoint;
    public Transform shieldSpawnPoint;
    public GameObject missile;

    public GameObject mine;
    public GameObject shield;

    void Start(){
        //Invoke("SpawnMissile",5f);
    }

    public void SpawnMissile( ){
        GameObject newMissile = MasterManager.NetworkInstantiate(missile,missileSpawnPoint.position,missileSpawnPoint.rotation) as GameObject;
        //newMissile.GetPhotonView().RPC("RPC_SetTarget",RpcTarget.AllBuffered,GameObject.FindGameObjectsWithTag("Target")[0].name);
        //Invoke("SpawnMissile",2f);
    }
    public void SpawnMine( ){
        GameObject newMine = MasterManager.NetworkInstantiate(mine,mineSpawnPoint.position,mineSpawnPoint.rotation) as GameObject;
    }
    public void SpawnShield(){
         GameObject newShield = MasterManager.NetworkInstantiate(shield,shieldSpawnPoint.position,shieldSpawnPoint.rotation) as GameObject;
         newShield.GetPhotonView().RPC("RPC_SetParent",RpcTarget.AllBuffered,PhotonNetwork.LocalPlayer.NickName);
         StartCoroutine(NetworkDestroy(newShield));
    }
    IEnumerator NetworkDestroy(GameObject newShield){
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(newShield);
    }
     
}
