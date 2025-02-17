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

    [Header("Enemie")]
    public bool EnemiesSpawned = false;
    public SpawnEnemy[] EnemyNodes;

    Transform parentTransform;

    void Start()
    {
        PlayerHitbox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        // Get the parent object
        parentTransform = transform.parent;

        SetEnemyNodes();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == PlayerHitbox)
        {
            Invoke("ActivateDoors", 1.0f);
            SetCamera();
            Debug.Log("Settings "+ MainCamera.name+ " to "+ cameranode.transform );
            
        }

    }

    private void Update()
    {
        if (EnemiesSpawned)
        {
            if (EnemyNodes.Length == 0)
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
        foreach (GameObject t in Doors) // instead of doing this create the doors before hand and set them to active or not
        {
            Doors[Door].SetActive(true);
            Door++;
        }
        foreach(SpawnEnemy i in EnemyNodes)
        {
            Debug.Log("Attempting to spawned enemy: " + Enemy);
            EnemyNodes[Enemy].Spawn();
            Enemy++;
        }
       // EnemiesSpawned = true;
    }
    private void SetCamera()
    {
        MainCamera.position = new Vector3(cameranode.position.x, cameranode.position.y , MainCamera.position.z);
    }

    private void DestroyDoors()
    {
        int Door = 0;
        foreach (GameObject t in Doors) // instead of doing this create the doors before hand and set them to active or not
        {
            Destroy(Doors[Door]);
            Door++;
        }
        Destroy(gameObject);
    }

    private void SetEnemyNodes()
    {
        Debug.Log("Attempting to set enemies");
        int i = 0;
        // Loop through all child objects of the parent object
        foreach (Transform child in parentTransform)
        {
            if (child.name == "EnemyNode")
            {
                EnemyNodes[i] = child.GetComponent<SpawnEnemy>();
                Debug.Log("EnemyNodes as obtained: " + i + " enemies");
                i++;
            }

        }
    }
}
