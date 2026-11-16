using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwaper : MonoBehaviour
{
    public void SwapScene(string GoalSceneName)
    {
        SceneManager.LoadScene(sceneName: GoalSceneName);
    }
}
