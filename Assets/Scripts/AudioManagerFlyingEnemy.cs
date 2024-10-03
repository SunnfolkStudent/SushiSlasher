using UnityEngine;

public class AudioManagerFlyingEnemy : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip[] flyingEnemyDeathSounds;
    private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(flyingEnemyDeathSounds[Random.Range(0, flyingEnemyDeathSounds.Length)]);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
