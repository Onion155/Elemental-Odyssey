using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private EnemieList enemies;
    private int rand;
    
    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("EnemyList").GetComponent<EnemieList>(); // finding the list of enemies in the current scene
        
    }

   public void Spawn(Transform parent)
    {
        GameObject newEnemy;
        rand = Random.Range(0,enemies.Enemies.Length);
        newEnemy = Instantiate(enemies.Enemies[rand],transform.position , Quaternion.identity);
        newEnemy.transform.SetParent(parent);
        Debug.Log("Spawned Enemy: "+ enemies.Enemies[rand].name);
        Destroy(gameObject);
    }
}
