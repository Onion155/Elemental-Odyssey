using Unity.VisualScripting;
using UnityEngine;

public class GateControler : MonoBehaviour
{
    // this should teleport the player to the next room or to the boss roo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // teleports player 
        }
    }
}
