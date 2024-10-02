using UnityEngine;
using UnityEngine.InputSystem;


public class BasicEnemyScript : MonoBehaviour
{
    private float speed = 6; //speed for the basic enemy
    public Rigidbody2D rb; //variable for the rigidbody
    
    [Header("Audio")]
    public GameObject onDeathSoundPlayer;
    public Transform onDeathSoundPlayerTransform;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//fetches the rigidbody component from the gameobject
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = speed;//sets the movement to move along the X,axis * speed
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KillBox") == false)//checks if enemy has hit a kill box
        {
            
            var clone = Instantiate(onDeathSoundPlayer, onDeathSoundPlayerTransform.position, Quaternion.identity); 
            clone.GetComponent<AudioManager>();
            
            Destroy(gameObject);//destroys enemy
            Destroy(other.gameObject);//destroys gameobject enemy has hit
            ScoreManager.score += 100;//adds a score of 100
        }
    }
}