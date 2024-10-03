using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    private float speed = 10f; //dictates speed of enemy
    public Rigidbody2D rb; //gives it interaction with its rigidbody?

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//finds the rigidbody component
    }
     void FixedUpdate()
     {
         rb.linearVelocityX = speed; //sets the enemys speed along the X,axis to the variable speed
     }

     private void OnDestroy()
     {
         ScoreManager.Score += 200;
     }
}
