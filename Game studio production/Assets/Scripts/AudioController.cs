using Ink.Parsed;
using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    List<AudioClip> audioClips;
    [SerializeField]
    List<AudioClip> CurrentClipSelection;
    [SerializeField]
    bool RandomClip;
    private void Start()
    {
        CurrentClipSelection.AddRange(audioClips);
    }
    public void Selectclip()
    {
        if (CurrentClipSelection.Count <= 0)
        {
            CurrentClipSelection.AddRange(audioClips);
        }
        int Selcetion=0;
        if (RandomClip)
        {
            Selcetion = Random.Range(0, CurrentClipSelection.Count-1);
        }
        else
        {
            Selcetion = CurrentClipSelection.Count-1;
        }

        CurrentClipSelection.Remove(PlayClip(CurrentClipSelection[Selcetion]));
    }
    AudioClip PlayClip(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        return clip;
    }
}
