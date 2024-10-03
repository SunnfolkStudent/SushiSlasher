using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("TankEnemy") == false)
            {
                Destroy(other.gameObject);
            }
        }
    
}
