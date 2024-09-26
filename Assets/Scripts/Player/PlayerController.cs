using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;

    public int playerHealth = 3;
    public float damageCooldown = 0.3f;
    private float _damageCooldownTimer;
    
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize,0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }
        
        Attack();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _input.Movement * moveSpeed;
    }

    private void Attack()
    {
        if (!Physics2D.OverlapCircle(groundCheck.position, 0.2f, LayerMask.GetMask("Enemy"))) return;
        var enemyColliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, LayerMask.GetMask("Enemy"));

        foreach (var enemy in enemyColliders)
        {
            Destroy(enemy.gameObject);
        }

        _rigidbody2D.linearVelocityY = jumpSpeed / 1.3f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TakeDamage()
    {
        if (Time.time > _damageCooldownTimer)
        {
            playerHealth -= 1;
            _damageCooldownTimer = Time.time + damageCooldown;
        }

        if (playerHealth <= 0)
        {
            RestartScene();
        }    
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }    
    }
}
