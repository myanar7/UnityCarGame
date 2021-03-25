using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinCanvases;
    public CreateOrJoinRoomCanvas CreateOrJoinCanvases{get{return _createOrJoinCanvases;}}

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvases;
    public CurrentRoomCanvas CurrentRoomCanvases{ get{ return _currentRoomCanvases;}}
    
    private void Awake() {
        FirstInitialize();
    }
    private void FirstInitialize(){
        CreateOrJoinCanvases.FirstInitialized(this);
        CurrentRoomCanvases.FirstInitialized(this);
    }
}
