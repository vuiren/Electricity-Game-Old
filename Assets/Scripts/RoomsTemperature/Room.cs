using TNRD.Autohook;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Room[] connectedRooms;

    [AutoHook]
    public RoomState roomState;
}
