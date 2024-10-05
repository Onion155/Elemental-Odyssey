using UnityEngine;

public class GateControler : MonoBehaviour
{
    public Rigidbody2D Player;
    public BoxCollider2D GateToo;
    public float spawnlocation;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(gameObject.name + " was entered by "+ collision.gameObject.name);
        Player.transform.position = new Vector2(GateToo.transform.position.x + spawnlocation, GateToo.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
