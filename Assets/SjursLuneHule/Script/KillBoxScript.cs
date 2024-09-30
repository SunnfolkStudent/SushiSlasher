using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("TankEnemy") == false)
            {
                Destroy(other.gameObject);
            }
        }
    
}
