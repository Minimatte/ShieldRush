using UnityEngine;
using System.Collections;

public class MenuAudio : MonoBehaviour {

    [SerializeField]
    AudioSource yesSound;
    [SerializeField]
    AudioSource noSound;
    [SerializeField]
    AudioSource hoverSound;

    public void ActivateSoundPlay()
    {
        yesSound.Play();
    }

    public void DeactivateSoundPlay()
    {
        noSound.Play();
    }

    public void HoverSoundPlay()
    {
        hoverSound.Play();
    }
}
