using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Missile : MonoBehaviourPun
{

    Transform target;
    Vector3 direction;
    float speed = 20;
    float rotationSpeed = 15;
    public GameObject explotion;

     private void Start() {
         if(!base.photonView.IsMine || GameObject.FindGameObjectsWithTag("Target").Length==0)return;
         target = GameObject.FindGameObjectsWithTag("Target")[0].transform;
    }
    void Update()
    {
        if(!base.photonView.IsMine) return;
        //Movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
        //Rotation
        if(target != null){
            direction = target.position - transform.position;
            direction = direction.normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime); 
        }
    }

    void OnTriggerEnter(Collider col){
        
        if(col.gameObject.CompareTag("Player") ){

            this.photonView.RPC("RPC_Explotion",RpcTarget.AllBuffered);
            col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(5000000f,transform.position-Vector3.down,10f);
            //base.photonView.RPC("RPC_Destroy",RpcTarget.AllBuffered,base.photonView.ViewID);
            this.photonView.RPC("RPC_Destroy",this.photonView.Owner);
            
        }else if(col.gameObject.CompareTag("Shield") && col.gameObject.GetPhotonView().IsMine){
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
