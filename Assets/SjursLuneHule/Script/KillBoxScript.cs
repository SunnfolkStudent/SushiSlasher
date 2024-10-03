using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
        {
                if (other.gameObject.CompareTag("BasicEnemy") == true)
                {
                        Destroy(other.gameObject);
                        ScoreManager.Score -= 100;
                }
                
                if (other.gameObject.CompareTag("FlyingEnemy") == true)
                {
                        Destroy(other.gameObject);
                        ScoreManager.Score -= 200;
                }
            
        }
    
}
