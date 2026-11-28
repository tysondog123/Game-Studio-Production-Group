using UnityEngine;
using UnityEngine.Video;


public class _CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private _CutsceneManager cutsceneManager;
    
    [SerializeField] private VideoClip cutsceneClip;
    
    [SerializeField] private bool playOnce = true;
    
    [SerializeField] private bool playOnStart;

    [SerializeField] private float startDelay = 0f;

    [SerializeField] private GameObject UIElement;

    private bool hasPlayed;

    private void Start()
    {
        if (playOnStart)
            Invoke(nameof(TriggerCutscene), startDelay);
    }

    public void TriggerCutscene()
    {
        if (playOnce && hasPlayed)
            return;

        cutsceneManager.PlayCutscene(cutsceneClip);

        hasPlayed = true;

        UIElement.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            TriggerCutscene();
    }
}
