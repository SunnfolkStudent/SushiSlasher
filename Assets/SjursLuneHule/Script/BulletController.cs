using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float despawnTime = 8f;
    public Rigidbody2D rigidBody2D;


    private void Start()
    {
        Destroy(gameObject, despawnTime);
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidBody2D.linearVelocity = Vector2.right * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
