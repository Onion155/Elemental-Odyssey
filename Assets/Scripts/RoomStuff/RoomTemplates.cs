using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [Header("MainStucture")]
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    [Header ("InnertSections")]
    public GameObject[] innerSections;

    [Header("Walls")]
    public GameObject closedRoom;
}

