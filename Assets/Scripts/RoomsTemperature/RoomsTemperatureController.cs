using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using UnityEngine;

public class RoomsTemperatureController : MonoBehaviour
{
    public Room[] rooms;

    private void Awake()
    {
        rooms = FindObjectsOfType<Room>();
    }

    [Command]
    public void CalculateRoomsTemperature()
    {
        var visitedRooms = new HashSet<Room>();
        foreach (var room in rooms)
        {
            if (visitedRooms.Contains(room))
                continue;

            var connectedRooms = GetAllConnectedRooms(room);
            var avgTemperature = GetAverageTemperatureInRooms(connectedRooms.ToArray());
            room.roomState.roomTemperature = avgTemperature;
            foreach (var connectedRoom in connectedRooms)
            {
                visitedRooms.Add(connectedRoom);
                connectedRoom.roomState.roomTemperature = avgTemperature;
            }
        }
    }

    private float GetAverageTemperatureInRooms(Room[] rooms)
    {
        var avgTemperature = 0f;

        for (int i = 0; i < rooms.Length; i++)
        {
            avgTemperature += rooms[i].roomState.roomTemperature;
        }

        avgTemperature /= rooms.Length;

        return avgTemperature;
    }

    private IEnumerable<Room> GetAllConnectedRooms(Room room)
    {
        var connectedRooms = new List<Room>();

        GetAllConnectedRoomsRecursive(room, connectedRooms);
        return connectedRooms;
    }

    private void GetAllConnectedRoomsRecursive(Room room, List<Room> connectedRooms)
    {
        connectedRooms.Add(room);
        foreach (var connectedRoom in room.connectedRooms)
        {
            GetAllConnectedRoomsRecursive(connectedRoom, connectedRooms);
        }
    }
}