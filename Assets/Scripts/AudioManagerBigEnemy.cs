using UnityEngine;

public class AudioManagerBigEnemy : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip bigEnemyDeathSound;
    private AudioSource _audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(bigEnemyDeathSound);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
