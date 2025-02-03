using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Player;

    public GameObject PlayerSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Player, PlayerSpawnPoint.transform.position , Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
