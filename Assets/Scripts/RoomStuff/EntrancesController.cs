using UnityEngine;

public class EntrancesController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D PlayerHitbox;
    public Transform[] DoorSpawnPoints;
    void Start()
    {
        PlayerHitbox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == PlayerHitbox)
        {
            CreateDoors();
            
        }

    }

    private void CreateDoors()
    {
        int Door = 0;
        foreach (Transform t in DoorSpawnPoints)
        {
            // Create a new GameObject
            GameObject square = new GameObject("Square");

            // Add a SpriteRenderer component
            SpriteRenderer renderer = square.AddComponent<SpriteRenderer>();

            // Create a new 2D texture (a simple white square)
            Texture2D texture = new Texture2D(15, 15);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();

            // Create a new sprite using the texture
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            renderer.sprite = sprite;

            // Set the position of the square
            square.transform.position = DoorSpawnPoints[Door].position;
            Door++;
        }
    }


}
