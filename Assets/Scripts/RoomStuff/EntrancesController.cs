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
    public bool EnemiesDead = false;

    void Start()
    {
        PlayerHitbox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
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
        if (EnemiesDead)
        {
            DestroyDoors();
        }
    }

    private void ActivateDoors()
    {
        int Door = 0;
        foreach (GameObject t in Doors) // instead of doing this create the doors before hand and set them to active or not
        {
            Doors[Door].SetActive(true);
            Door++;
        }
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
}
