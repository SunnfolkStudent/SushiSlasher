using System;
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
    
    private void OnDestroy()
    {
        Instantiate(onDeathSoundPlayer, onDeathSoundPlayerTransform.position, Quaternion.identity); 
        ScoreManager.Score += 100;
    }
}