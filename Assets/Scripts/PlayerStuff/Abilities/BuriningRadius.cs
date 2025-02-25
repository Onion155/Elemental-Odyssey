using UnityEngine;

public class BuriningRadius : MonoBehaviour
{
    public float Damage = 1.0f;
    public float LifeTime = 2000;

    [Header("Refernaces")]
    public Transform PT;

    private void Awake()
    {
        PT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.SetParent(PT);
    }
    private void Update()
    {
        if (LifeTime >0)
        {
            LifeTime--;
        }
        else { Destroy(gameObject); }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            DealDamage(collision.gameObject);
            Debug.Log("Trying to deal damage");

        }
    }

    protected void DealDamage(GameObject target)
    {
        target.GetComponent<Enemy>().Damage(Damage); // this works even if the object has a child script that inherits from this script

    }
}
