using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 -- bottom door
    //2 -- top door
    //3 -- left door
    //4 -- right door

    // need to do-- make a referance to the grid and then make the everything i child of it

    private Transform parentObject;
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    // this needs to be optimised its going to affect my game if it has to search all the objects to find these tags
    private void Start()
    {
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      parentObject = GameObject.FindGameObjectWithTag("RoomSeed").GetComponent<Transform>(); // this is a referance to the grid 
        Invoke("Spawn", 0.9f);
    }
    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                GameObject newObject =Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 2)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                GameObject newObject = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 3)
            {
                // spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                GameObject newObject = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 4)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                GameObject newObject = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                newObject.transform.SetParent(parentObject);
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint")&& collision.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(this.gameObject);
        }
    }
}
