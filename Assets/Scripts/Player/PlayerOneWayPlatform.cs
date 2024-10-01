using System.Collections;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private InputActions _input;
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    private void Start()
    {
        _input = GetComponent<InputActions>();
    }
    
    void Update()
    {
        if (_input.Vertical < 0)
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.75f); // This needs to be increased or decreased depending on player and platform size, if this is wrong the player will get stuck inside the platform instead of falling through
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
    
}
