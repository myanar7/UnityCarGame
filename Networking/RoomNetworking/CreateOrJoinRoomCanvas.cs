using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    [SerializeField]
    private RoomListingMenu _roomListingMenu;
    private RoomsCanvases _roomsCanvases;

    public void FirstInitialized(RoomsCanvases canvases) {
        _roomsCanvases=canvases;
        _createRoomMenu.FirstInitialized(canvases);
        _roomListingMenu.FirstInitialized(canvases);
    }
}
