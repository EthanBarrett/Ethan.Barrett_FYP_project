using UnityEngine;


public class enemySpawner : MonoBehaviour
{

    public GameObject enemyPre;
    public Transform spawnPoint;

    public void SpawnEnemy()
    {
        

        GameObject newEnemy = Instantiate(enemyPre, spawnPoint.position, spawnPoint.rotation);

        Enemys enemyScript = newEnemy.GetComponent<Enemys> ();
        enemyScript.InitializeEnemy();
        
    }
    
}
