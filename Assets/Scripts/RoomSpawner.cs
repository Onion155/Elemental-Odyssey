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
    private GameObject newObject;

    private int rand;
    private bool spawned = false;
    public float waitTime = 4f;

    // this needs to be optimised its going to affect my game if it has to search all the objects to find these tags
    private void Start()
    {
        Destroy(gameObject, waitTime); // destroys the unneccasary nodes once they have been used 

      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
      parentObject = GameObject.FindGameObjectWithTag("RoomSeed").GetComponent<Transform>(); // this is a referance to the grid 
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                newObject = Instantiate(templates.topRooms[rand], transform.position , templates.topRooms[rand].transform.rotation); //+fixdown
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 2)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                newObject =  Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);//+ fixup
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 3)
            {
                // spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                newObject = Instantiate(templates.rightRooms[rand], transform.position , templates.rightRooms[rand].transform.rotation);//+ fixleft
                newObject.transform.SetParent(parentObject);
            }
            else if (openingDirection == 4)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                newObject = Instantiate(templates.leftRooms[rand], transform.position , templates.leftRooms[rand].transform.rotation);//+ fixright
                newObject.transform.SetParent(parentObject);
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                newObject = Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                newObject.transform.SetParent(parentObject);

                Destroy(gameObject);
                Debug.Log("Destroyed " + gameObject.name);
            }
            spawned = true;
        }
    }
}
