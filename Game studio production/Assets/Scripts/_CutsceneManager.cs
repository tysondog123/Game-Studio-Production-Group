using UnityEngine;
using UnityEngine.Video;

public class _CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cutscenePanel;

    [SerializeField] private VideoPlayer videoPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayCutscene(VideoClip clip)
    {
        cutscenePanel.SetActive(true);
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    private void EndCutscene(VideoPlayer source)
    {
        cutscenePanel.SetActive(false);
    }

    private void OnEnable()
    {
        videoPlayer.loopPointReached += EndCutscene;
    }

    private void OnDisable()
    {
        videoPlayer.loopPointReached -= EndCutscene;
    }

}
