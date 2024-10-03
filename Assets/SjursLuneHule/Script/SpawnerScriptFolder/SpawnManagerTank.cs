using UnityEngine;

public class SpawnManagerTank : MonoBehaviour
{
    public float time = 20f;
    public float timeCounter = 0f;

    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    
    private void Update()
    {
        
        if (timeCounter < Time.time && ScoreManager.Score >=3000)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            timeCounter = Time.time + Random.Range(1, time);
        }
        

         if (ScoreManager.Score == 8000)
         {
             time = 10f;
         }

         if (ScoreManager.Score == 14000)
         {
             time = 5f;
         }
    }
}
