using UnityEngine;

public class ElementControl : MonoBehaviour 
{
    // this is for the player it constrols what elements they have control of and what abilites to have
    [SerializeField]
    private GameObject[] ProjectileList;

    private int a = 0;

    public Vector3 ProjectileSpeed = new Vector3(0.2f, 0, 0);
    public GameObject[] ElementalProjectiles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Firing Bullet!");
            CreateProjectile();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < ProjectileList.Length; i++)
        {
            ProjectileList[i].transform.position += ProjectileSpeed;
        }
    }
    public void CreateProjectile()
    {
        GameObject newPorjectile = new GameObject("Projectile " + a);
        newPorjectile.transform.SetParent(ProjectileList[a].transform);
        a++;
    }
}
