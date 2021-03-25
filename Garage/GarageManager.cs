using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GarageManager : MonoBehaviour
{
    [HideInInspector] public GameObject car;
    public GameObject carSpawnPoint;
    private int carNumber;

    public GameObject [] carList;
    // Start is called before the first frame update

    private void Awake() {
        carNumber = 0;
        carInstantiate();
    }
    private void carInstantiate(){
        car = Instantiate(carList[carNumber],carSpawnPoint.transform.position, carSpawnPoint.transform.rotation);
        car.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        car.GetComponent<VehicleControl>().enabled=false;
    }
    
    
    public void nextCar(){
        Destroy(car);
        carNumber++;
        carNumber = (carNumber >= carList.Length)? carNumber - carList.Length : carNumber;
        carInstantiate();
    }

    public void previousCar(){
        Destroy(car);
        carNumber--;
        carNumber = (carNumber < 0)? carNumber + carList.Length : carNumber;
        carInstantiate();

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.G)){
            nextCar();
        }
        else if(Input.GetKeyDown(KeyCode.F)){
            nextCar();
        }
    }
    public GameObject InstantiateChosenCar(){
        return carList[carNumber];
    }
}
