using UnityEngine;

public class ThrowingEnemyScriptReverse : MonoBehaviour
{
    private float speed = -3f;//dictates speed of the enemy
    public Rigidbody2D rb;

    public GameObject bulletPrefab;//allows me to add the bullet prefab to this script
    public GameObject[] spawnPoints;//how many points it can spawn at

    public float time = 10;//time between shots
    public float timeCounter = 0f;//counter of time

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//fetches the rigidbody component
    }

    private void Update()
    {
        if (timeCounter < Time.time)//checks if the timecounter is less than? greater? i still dont understand those crocodile mouths
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);//decides which spawnpoint it will spawn at great if there are more but still works with 1
            Instantiate(bulletPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);//spawns a bullet
            timeCounter = Time.time + Random.Range(1, time);//decides the time for the shot
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = speed;//sets speed to follow the speed variable
    }

    private void OnTriggerEnter2D(Collider2D other)//on touching the player will be changed later
    {
        if (other.gameObject.CompareTag("Player") == true)//yeah what the other says
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            ScoreManager.Score += 250;
        }
    }
}
