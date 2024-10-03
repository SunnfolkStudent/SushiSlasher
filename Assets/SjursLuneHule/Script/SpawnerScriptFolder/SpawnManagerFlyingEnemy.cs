using UnityEngine;

public class SpawnManagerFlyingEnemy : MonoBehaviour
{
    public float time = 10f;
    public float timeCounter = 0f;

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    
    private void Update()
    {
        
        if (timeCounter < Time.time && ScoreManager.Score >= 1000)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            timeCounter = Time.time + Random.Range(1, time);
        }
        
         if (ScoreManager.Score == 5000)
         {
             time = 5f;
         }

         if (ScoreManager.Score == 9000)
         {
             time = 2.5f;
         }
         
    }
}
