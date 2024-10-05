using UnityEngine;

public class FlyingEnemyScriptReverse : MonoBehaviour
{
    private float speed = -10f; //dictates speed of enemy
    public Rigidbody2D rb; //gives it interaction with its rigidbody?
    
    [Header("Audio")]
    public GameObject onDeathSoundPlayer;
    public Transform onDeathSoundPlayerTransform;
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
        if (onDeathSoundPlayerTransform.transform.position.x >= -9.9f)
        {
            Instantiate(onDeathSoundPlayer, onDeathSoundPlayerTransform.position, Quaternion.identity);
        }
        
        ScoreManager.Score += 200;
    }
}
