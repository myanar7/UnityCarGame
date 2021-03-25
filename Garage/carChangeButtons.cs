using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carChangeButtons : MonoBehaviour
{
    GameObject manager;
    
    private void Start() {
        manager = GameObject.Find("GarageManager");
    }
    public void nextCarButtonClick(){
        manager.GetComponent<GarageManager>().nextCar();
    }
    public void previousCarButtonClick(){
        manager.GetComponent<GarageManager>().previousCar();
    }

}
