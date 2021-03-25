using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Mine : MonoBehaviourPun 
{
    public GameObject explotion;
   
    public void OnCollisionEnter(Collision col){
        
       if(col.gameObject.CompareTag("Player")){
            
            this.photonView.RPC("RPC_Explotion",RpcTarget.AllBuffered);
            col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(5000000f,transform.position-Vector3.down,10f);
            //base.photonView.RPC("RPC_Destroy",RpcTarget.AllBuffered,base.photonView.ViewID);
            this.photonView.RPC("RPC_Destroy",this.photonView.Owner);
        }
            
    }
    public void OnTriggerEnter(Collider col){
         if(col.gameObject.CompareTag("Shield") && col.gameObject.GetPhotonView().IsMine){
           this.photonView.RPC("RPC_Destroy",this.photonView.Owner);
        }
    }
     [PunRPC]
    public void RPC_Destroy(){

       PhotonNetwork.Destroy(gameObject);
    }
    [PunRPC]
    public void RPC_Explotion(){

       Instantiate(explotion,transform.position,Quaternion.identity);
    }
}
