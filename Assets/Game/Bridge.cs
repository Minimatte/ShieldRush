using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {

    public AudioSource source;
    public AudioClip finishedSound, loopingSound;
    public void PlaySound() {
        source.clip = loopingSound;
        source.Play();
    }

    public void StopSound() {
        source.Stop();
        source.PlayOneShot(finishedSound);
    }
}
