using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public LayerMask GroundMask;
    private void Start()
    {
       Destroy(gameObject, 4f); // destoys this node after it has done what it needs to

        Debug.Log(GroundMask);
    }
    void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(other.gameObject);
    }
}
