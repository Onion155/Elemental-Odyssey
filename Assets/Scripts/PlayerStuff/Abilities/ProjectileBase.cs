using UnityEditor.ShaderGraph;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("BaseStats")]
    public float ProjectileSpeed = 1.0f;
    public int ProjectileLifeTime = 1000;
    public float Damage = 1.0f;

    [Header("Refernaces")]
    public Rigidbody2D Rb;

    protected void Move()
    {
        if (ProjectileLifeTime > 0)
        {
            Rb.velocity = new Vector2(ProjectileSpeed, Rb.velocity.y);
            ProjectileLifeTime--;
        }
        else { Destroy(gameObject); }
    }

    protected void CheckDirection()
    {
        if (Rb.transform.lossyScale.x == 2)
        {
            // should go left
            ProjectileSpeed *= -1;
            Debug.Log("Projectile Moving left");
        }
        else { Debug.Log("Projectile Moving Right"); }
    }

    protected void DealDamage(GameObject target)
    {
        target.GetComponent<Enemy>().Damage(Damage); // this works even if the object has a child script that inherits from this script
        
    }
   

}
