using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateControler : MonoBehaviour
{
   public string scene;
    // this should teleport the player to the next room or to the boss roo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
            Debug.Log("Hello from trigger");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello from collision");
    }
}
