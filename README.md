# Unity 3D Battle Car Game !

### Headers
1. <a href="#car-controller">Car Controller</a>
2. <a href="#skills">Skills</a>
   * <a href="#mine">Mine</a>
   * <a href="#shield">Shield</a>
   * <a href="#missile">Missile</a>
4. <a href="#networking">Networking</a>
5. <a href="#garage">Garage</a>
6. <a href="#minimap">Minimap</a>
7. <a href="#firebase">Firebase</a>
8. <a href="#built-with">Built With</a>

## Car Controller

There are four car control script. One of them are on the main camera, the others are on the vehicle. Firstly, [Vehicle Camera](https://github.com/myanar7/experience1/edit/main/CarController/VehicleCamera.cs) find the vehicle of the player automatically or manually (There is an option on the script for that) then all inputs to control the vehicle is entered by this script. The values which changed by the inputs are measured by the [Vehicle Control](https://github.com/myanar7/experience1/edit/main/CarController/VehicleControl.cs) and the vehicle moves.

## Skills
We have 3 type skill in the game. 
* Mine
* Shield
* Missile
### Mine

When the landmine collided with the vehicle, The vehicle are scattered by exploding force of the landmine. the vehicle gets damage and the landmine destroys itself from server (and all clients).


![](ReadMeResources/Mine.gif)

### Shield

Shield protect your car from any damage. When your vehicle collides with missile or landmine, it runs explotion particial effects and destroy these skills. It disappears after 5 second.


![](ReadMeResources/Shield.gif)

### Missile

Missile is locked its target. It goes towards the target.The transform datas distribute to all clients by the owner client of the missile. When the missile collides any car which does not have shield buff, then the vehicle gets damage and the missile destroys itself from server. 


![](ReadMeResources/Missile.gif)

## Networking

There is four step to connect to the game. Firstly, you have to stable internet connection to connect to PUN2 Server. You will join priority lobby automatically when you connected with the server. 

## Built With

* [Unity](https://unity.com/)
* [Photon2](https://www.photonengine.com/)

