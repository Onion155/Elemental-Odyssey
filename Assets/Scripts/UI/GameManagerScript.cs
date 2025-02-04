using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform PlayerPos;

    public Transform PlayerSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPlayerPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetPlayerPos()
    {
        PlayerPos.position = PlayerSpawnPoint.position;
    }
}
