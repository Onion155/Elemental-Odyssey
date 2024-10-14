using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 -- needs bottom door
    //2 -- needs top door
    //3 -- needs left door
    //4 -- needs right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Start()
    {
      templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
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
