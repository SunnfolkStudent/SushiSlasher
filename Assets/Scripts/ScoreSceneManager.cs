using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneManager : MonoBehaviour
{
    [Header("Components")]
    private InputActions _input;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<InputActions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.Play) // Change this if you want to use a different key
        {
            //NextScene();
            QuitGame();
        }
    }

    /*
    private void NextScene()
    {
        SceneManager.LoadScene("Scenes/PressToPlay");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
