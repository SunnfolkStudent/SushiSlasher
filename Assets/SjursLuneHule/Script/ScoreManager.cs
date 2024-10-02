using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static int Score = 0; //just sets the variable for score. static makes the variable global and saves between scenes
    public TMP_Text scoreDisplay; //variable were we have to drag and drop in the ui textmesh for score
    private void Update()
    {
        scoreDisplay.text = "score: " + Score; //this makes the score be displayed correctly it adds the score variable it gets from enemy's onto the current score
    }
}
