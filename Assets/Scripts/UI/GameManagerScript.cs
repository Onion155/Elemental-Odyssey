using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private Transform PlayerPos;
    private Transform PlayerSpawnPoint;

    public RoomTemplates RoomTemplate;

    public Transform Grid;
    private GameObject newInternalTemplate;
    private int rand;
    private int oldrand;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("InsertSpecialRooms", 0.5f);
    }

    private void InsertSpecialRooms()
    {
        // search through the rooms and randomly replace 2 of the rooms 
        rand = Random.Range(1, Grid.childCount);
        Destroy(Grid.GetChild(rand).transform.GetChild(0).gameObject);
        CreateInnerRoom(Grid.GetChild(rand).transform, 0); // replace with boss door room

        oldrand = rand;

        rand = Random.Range(1, Grid.childCount);

        if (rand == oldrand) // this helps it not be the same room (bvut there is still a chance it could be the same room needs to be improved!
        {
            rand = Random.Range(1, Grid.childCount);
        }

        Destroy(Grid.GetChild(rand).transform.GetChild(0).gameObject);
        CreateInnerRoom(Grid.GetChild(rand).transform, 1);  // replace with npc room
    }

    void ResetPlayerPos()
    {
        PlayerPos.position = PlayerSpawnPoint.position;
    }

    private void CreateInnerRoom(Transform ParentTrans , int value)
    {
        newInternalTemplate = Instantiate(RoomTemplate.SpecialInnerSections[value], ParentTrans.position, RoomTemplate.SpecialInnerSections[value].transform.rotation);
        newInternalTemplate.transform.SetParent(ParentTrans);
        newInternalTemplate.transform.SetAsFirstSibling(); // sets it to the first position
    }
}

