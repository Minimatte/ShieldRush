using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    static AudioSource aSource;
    void Awake() {
        aSource = GetComponent<AudioSource>();
    }

    public static void PlaySoundOneshot(AudioClip soundClip) {
        aSource.PlayOneShot(soundClip);
    }

    public static void PlayCurrentSound() {
        aSource.Play();
    }

}
