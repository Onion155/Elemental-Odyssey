using Unity.VisualScripting;
using UnityEngine;

public class GateControler : MonoBehaviour
{
    // referances 
    public Rigidbody2D Player; // player who will be tpd
    public BoxCollider2D GateToo; // gate it will tp to

    private float spawnlocation = 0f;
    public bool rightside;
   

    private void Start()
    {
        //if (rightside)
        //{
         //   spawnlocation = -spawnlocation;
        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player.transform.position = new Vector2(GateToo.transform.position.x + spawnlocation, GateToo.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
