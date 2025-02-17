using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private EnemieList enemies;
    private int rand;
    
    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("EnemyList").GetComponent<EnemieList>(); // finding the list of enemies in the current scene
        //Spawn();
    }

   public void Spawn()
    {
        rand = Random.Range(0,enemies.Enemies.Length);
        Instantiate(enemies.Enemies[rand],transform.position , Quaternion.identity);
        Debug.Log("Spawned Enemy: "+ enemies.Enemies[rand].name);
        Destroy(gameObject);
    }
}
