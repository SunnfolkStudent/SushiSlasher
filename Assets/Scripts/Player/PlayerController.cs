using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    
    [Header("Health")]
    public int playerHealth = 3;
    public float damageCooldown = 0.3f;
    private float _damageCooldownTimer;
    
    [Header("Ground Check")]
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    
    [Header("Components")]
    private InputActions _input;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Audio")]
    public AudioClip[] playerHitSounds;
    public AudioClip[] playerJumpSounds;
    //public AudioClip playerDeathSound;
    private AudioSource _audioSource;
    
    [Header("Animation")]
    private Animator _animator;
    
    private bool isFacingRight = true;
    
    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize,0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            _audioSource.PlayOneShot(playerJumpSounds[Random.Range(0, playerHitSounds.Length)]);
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }
        
        if (!isFacingRight && _rigidbody2D.linearVelocityX > 0)
        {
            Flip();
        }
        else if (isFacingRight && _rigidbody2D.linearVelocityX < 0)
        {
            Flip();
        }
        
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
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
            _audioSource.PlayOneShot(playerHitSounds[Random.Range(0, playerHitSounds.Length)]);
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

    private void UpdateAnimation()
    {
        if (playerIsGrounded) // This checks if the player is grounded
        {
            if (_input.Horizontal != 0) // This checks if we have any input
            {
                _animator.Play("Player_Walk"); // If we have input set our animation to Walk
            }
            else // This checks if we have no input
            {
                _animator.Play("Player_Idle"); // If we have no input, set out animation to Idle
            }
        }
        else // this checks if the player is Not grounded
        {
            if (_rigidbody2D.linearVelocityY > 0) // This checks our velocity and if it is above 0
            {
                _animator.Play("Player_Jump"); // If we are moving upwards, set animation to Jump
            }
            else // This checks our velocity and if it is below 0
            {
                _animator.Play("Player_Fall"); // If we are moving downwards, set animation to Fall
            }
        }
    }
}
