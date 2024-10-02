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
        
        if (timeCounter < Time.time && ScoreManager.Score >=100)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            timeCounter = Time.time + Random.Range(1, time);
        }
        
    }
}
