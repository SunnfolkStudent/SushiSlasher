using UnityEngine;

public class TankEnemyScript : MonoBehaviour
{
    private float speed = 10f; //dictates speed of enemy
    public Rigidbody2D rb; //gives it interaction with its rigidbody?
    private int enemyHealth = 3;
    private float damageCooldown = 0f;
    private float _damageCooldownTimer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//finds the rigidbody component
    }
    void FixedUpdate()
    {
        rb.linearVelocityX = speed;//sets the enemys speed along the X,axis to the variable speed
    }

    private void TakeDamage()
    {
        if (Time.time > _damageCooldownTimer)
        {
            enemyHealth -= 1;
            _damageCooldownTimer = Time.time + damageCooldown;
        }

        if (enemyHealth < 0)
        {
            Destroy(gameObject);
            ScoreManager.score += 400;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KillBox") == true)
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KillBox") == false)
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
}
