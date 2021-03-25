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

When the landmine collided with the vehicle, The vehicle are scattered by exploding force of the landmine. the vehicle gets damage and the landmine destroys itself from server (and all clients).


![](ReadMeResources/Shield.gif)

### Missile

When the landmine collided with the vehicle, The vehicle are scattered by exploding force of the landmine. the vehicle gets damage and the landmine destroys itself from server (and all clients).


![](ReadMeResources/Missile.gif)
