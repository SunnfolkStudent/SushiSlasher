using UnityEngine;

public class TankEnemyScript : MonoBehaviour
{
    private float speed = 10f; //dictates speed of enemy
    public Rigidbody2D rb; //gives it interaction with its rigidbody?
    public float health = 3;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//finds the rigidbody component
    }
    void FixedUpdate()
    {
        rb.linearVelocityX = speed;//sets the enemys speed along the X,axis to the variable speed
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("KillBox") == false)//checks if the enemy has collided with a killbox or other
        {
            Destroy(gameObject);//destroys the enemy
            Destroy(other.gameObject);//destroys what it hit
            ScoreManager.score += 200;//adds a score of 200
        }

        if (other.gameObject.CompareTag("KillBox") == true)
        {
            rb.linearVelocityX = speed;
        }
    }
}
