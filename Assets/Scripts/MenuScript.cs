using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
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
        if (_input.Play)
        {
            NextScene();
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Scenes/Erik");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
