using UnityEngine;

public class BasicEnemyScriptReversed : MonoBehaviour
{
    private float speed = -6; //speed for the basic enemy
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)//checks if enemy has hit a kill box
        {
            
            var clone = Instantiate(onDeathSoundPlayer, onDeathSoundPlayerTransform.position, Quaternion.identity); 
            clone.GetComponent<AudioManager>();
            
            Destroy(gameObject);//destroys enemy
            ScoreManager.Score += 100;//adds a score of 100
        }
    }
}
