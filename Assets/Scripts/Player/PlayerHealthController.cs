using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public PlayerController player;
    public Image[] hearts;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.playerHealth)
            {
                //hearts[i].color = new Color(1, 0, 0, 1);
                //hearts[i].sprite = new Sprite("player_full_heart");
            }
            else
            {
                hearts[i].color = new Color(1, 1, 1, 0.2f);
            }
        }    
    }
}

