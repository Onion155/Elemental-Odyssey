using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.SpeedTree.Importer;
using UnityEngine;

public class EntrancesController : MonoBehaviour
{
    [Header ("Door")]
    [SerializeField]
    // door stuff
    private BoxCollider2D PlayerHitbox;
    public GameObject[] Doors;

    [Header("Camera")]
    // camera controls
    public Transform cameranode;
    private Transform MainCamera;
    private CameraControls CameraControler;

    [Header("Enemie")]
    public bool EnemiesSpawned = false;
    public List<SpawnEnemy> EnemyNodes = new List<SpawnEnemy>(); // all the spawning points for the enemies in a floor
    private Transform EnemieList; // all the enemies for each floor will be in here

    private bool RoomCleared = false;


    void Start()
    {
        PlayerHitbox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        EnemieList = transform.parent.GetChild(1); // make sure that the "enemies" is in the second position (dont forget the platforms are spawned as first always)
        CameraControler = MainCamera.gameObject.GetComponent<CameraControls>();
       Invoke("SetEnemyNodes",1.0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == PlayerHitbox)
        {
            SetCamera();
            if(!RoomCleared)
            {
                Invoke("ActivateDoors", 1.0f);
            }
            Debug.Log("Settings " + MainCamera.name + " to " + cameranode.transform);
            }
    }

    private void Update()
    {
        if (EnemiesSpawned && !RoomCleared)
        {
            if (EnemieList.transform.childCount <= 0)
            {
                DestroyDoors();
                Debug.Log("Room Cleared");
            }
        }
    }

    private void ActivateDoors()
    {
        int Door = 0;
        int Enemy = 0;
        foreach (GameObject t in Doors) // active door
        {
            Doors[Door].SetActive(true);
            Door++;
        }
        
        foreach (SpawnEnemy i in EnemyNodes) // spawn enemies
        {
            Debug.Log("Attempting to spawned enemy: " + Enemy);
            EnemyNodes[Enemy].Spawn(EnemieList);
            Enemy++;
                
        }
        EnemiesSpawned = true;
    }
    private void SetCamera()
    {
        MainCamera.position = new Vector3(cameranode.position.x, cameranode.position.y , MainCamera.position.z);

        CameraControler.SetLimits(new Vector2(cameranode.position.x, cameranode.position.x), new Vector2(cameranode.position.y, cameranode.position.y));
    }

    private void DestroyDoors() // this is called when room has been cleared
    {
        int Door = 0;
        foreach (GameObject t in Doors) 
        {
            Doors[Door].SetActive(false);
            Door++;
        }
        RoomCleared = true; // this will mean we dont try to spawn enemies in again
    }

    private void SetEnemyNodes()
    {
        // Get the parent object
        Transform Platform = transform.parent.GetChild(0);
       // Debug.Log("--------------------------");
       // Debug.Log(Platform.name);

       // Debug.Log("Attempting to set enemies");
  
        // Loop through all child objects of the parent object
        foreach (Transform child in Platform) // search platform children 
        {
           
            if (child.name == "EnemyNode") // if a node add it 
            {
               
                SpawnEnemy spawnEnemy = child.gameObject.GetComponent<SpawnEnemy>();

                if (spawnEnemy != null)
                {
                    EnemyNodes.Add(spawnEnemy);
                   // Debug.Log($"EnemyNodes has obtained: {EnemyNodes.Count} enemies");
                }
            }
        }
       // Debug.Log("--------------------------");
    }
}
