using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Explosion : MonoBehaviourPun
{
    
    void Start()
    {
        Destroy(gameObject,(GetComponent<ParticleSystem>().main.duration+GetComponent<ParticleSystem>().main.startLifetime.constantMax)/2);
    }
    
    
}
