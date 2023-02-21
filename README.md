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

There are four car control scripts. One of them is on the main camera, the others are on the vehicle. Firstly, [Vehicle Camera](https://github.com/myanar7/experience1/edit/main/CarController/VehicleCamera.cs) find the vehicle of the player automatically or manually (There is an option on the script for that) then all inputs to control the vehicle is entered by this script. The values which are changed by the inputs are measured by the [Vehicle Control](https://github.com/myanar7/experience1/edit/main/CarController/VehicleControl.cs) and the vehicle moves.

## Skills
We have 3 types of skills in the game. 
* Mine
* Shield
* Missile
### Mine

When the landmine collided with the vehicle, The vehicle is scattered by exploding force of the landmine. the vehicle gets damage and the landmine destroys itself from the server (and all clients). 

<p align="center">
  <img src="ReadMeResources/Mine.gif" alt="animated" />
</p>


### Shield

Shield protect your car from any damage. When your vehicle collides with a missile or landmine, it runs explosion partial effects and destroys these skills. It disappears after 5 seconds.

<p align="center">
  <img src="ReadMeResources/Shield.gif" alt="animated" />
</p>


### Missile

The missile is locked its target. It goes towards the target. The transformed data distribute to all clients by the owner client of the missile. When the missile collides with any car which does not have a shield buff, then the vehicle gets damage and the missile destroys itself from the server. .


<p align="center">
  <img src="ReadMeResources/Missile.gif" alt="animated" />
</p>


## Networking

There are four steps to connect to the game. Firstly, you have to stable internet connection to connect to PUN2 Server. You will join the priority lobby automatically when you connected with the server. Then the canvas changes to the lobby canvas. In the lobby canvas, you can create a room, leave the lobby and join a room from the room list which is on the right side of the canvas. When you join/create a room, your client joins the main server-based client. You see the other players on the list and start the game (the owner of the room has the only authority to start the game). Then the game will instantiate your vehicle in the terrain with all the players in the room.

## Garage

In the garage scene, there is a scrolling system to pass from car to car. All cars store in an array which index of it is # of cars. When you scroll to another car, destroy the car, and instantiate the new car (actually to use an object pool may be more efficient than that).In the last index of the array, we used a modular equation to get an infinite loop between all cars. There are also some UI components to show the properties of the vehicles. When you decided to choose what car you are going to drive, click the play button and load to the map.

## Minimap

There is a simple map in the game. We have used an orthographic camera and a UI render component to show the view of the camera on the canvas. Transform of camera update itself according to the vehicle.

## Firebase

<p align="center"><img src="https://focusyouthcentre.org/wp-content/uploads/2019/08/under-construction-2408061_960_720.png" width="250"></p>

## Built With

* [Unity](https://unity.com/)
* [Photon2](https://www.photonengine.com/)

