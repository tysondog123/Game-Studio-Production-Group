using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwaper : MonoBehaviour
{

    private static SceneSwaper instance;

    private void Awake()
    {
        if (instance != null && instance != this) // ensures that there is only one scene swaper running in each scene.
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SwapScene(string GoalSceneName)
    {
        SceneManager.LoadScene(sceneName: GoalSceneName);
    }

    public void StartGame() // on button press load scene Main
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGame() // to be added
    { 
    
    }

    public void Options() // to be added
    { 
    
    }

    public void Credits() // to be added
    { 
    
    }

    public void QuitGame() // on button press close application (build only)
    {
        Application.Quit();
    }

    public void Memories()
    { 
    
    }

    public void DialogueHistory()
    { 
    
    }

    public void BacktoGame()
    {
    
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMain");
    }

}
