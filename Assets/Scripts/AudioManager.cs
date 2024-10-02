using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip[] enemyTemariDeathSound;
    private AudioSource _audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(enemyTemariDeathSound[Random.Range(0, enemyTemariDeathSound.Length)]);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
