using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f; // 7.9f
    
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
    public AudioClip[] playerSlashSounds;
    //public AudioClip playerDeathSound;
    private AudioSource _audioSource;
    
    [Header("Animation")]
    public Animator _animator;
    
    [Header("Attacking")]
    public float attackCooldown = 1f;
    //private int attackCounter = 0;
    private float _attackCooldownTimer;
    
    private bool isFacingRight = true;
    
    //public UnityEvent OnLandEvent;
    
    private void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    //TODO: Put jumping into it's own functions like attacking to be able to implement separate jump attack
    
    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            //_animator.SetBool("isJumping", true);
            _audioSource.PlayOneShot(playerHitSounds[Random.Range(0, playerHitSounds.Length)]);
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }
        else if (_input.releaseJump && !playerIsGrounded && _rigidbody2D.linearVelocity.y > 0f)
        {
            _rigidbody2D.linearVelocityY /= 3f; //øk det for å hoppe mindre
        }

        //if (playerIsGrounded && _rigidbody2D.linearVelocity.y > 0f)
        /*
        if (playerIsGrounded)
        {
            _animator.SetBool("isJumping", false);
        }
        */
        if (_input.Attack && Time.time > _attackCooldownTimer)
        {
            _attackCooldownTimer = Time.time + attackCooldown;
            Attack();
        }
        
        switch (isFacingRight)
        {
            case false when _rigidbody2D.linearVelocityX > 0:
            case true when _rigidbody2D.linearVelocityX < 0:
                Flip();
                break;
        }
        
        _animator.SetFloat("SpeedY", Mathf.Abs(_rigidbody2D.linearVelocityY));
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.linearVelocityX));
    }
    /*
    public void OnLanding()
    {
            _animator.SetBool("isJumping", false);
    }
    */
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
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }    
    }

    private void Attack()
    {
        _audioSource.PlayOneShot(playerSlashSounds[Random.Range(0, playerSlashSounds.Length)]);
        //attackCounter += 1;
        //_animator.SetInteger("Slash", attackCounter);
        _animator.SetBool("isAttacking", true);
        Invoke("AttackEnd", 0.6f);
    }

    private void AttackEnd()
    {
        //attackCounter = 0;
        _animator.SetBool("isAttacking", false);
    }
}