using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class ThrowingEnemyScript : MonoBehaviour
{
    private float speed = 3f;
    public Rigidbody2D rb;

    public GameObject bulletPrefab;
    public GameObject[] spawnPoints;

    public float time = 10;
    public float timeCounter = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(bulletPrefab, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            timeCounter = Time.time + Random.Range(1, time);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = speed;
    }
}
