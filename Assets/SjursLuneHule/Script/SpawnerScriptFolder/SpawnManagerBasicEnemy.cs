using Unity.VisualScripting;
using UnityEngine;

public class SpawnManagerBasicEnemy : MonoBehaviour
{
    public float time = 10f;
    public float timeCounter = 0f;

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    
    private void Update()
    {
        
        if (timeCounter < Time.time)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            timeCounter = Time.time + Random.Range(1, time);
        }
        
        /* if you use this code you can reduce spawn time at certain score levels WOWIE
         if (ScoreManager.Score == Number)
         {
            time = Number to replace the standard time;
        }
         */
    }
}
