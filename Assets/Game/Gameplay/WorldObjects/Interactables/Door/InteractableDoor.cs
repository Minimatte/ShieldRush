using UnityEngine;
using System.Collections;
using System;

public class InteractableDoor : Interactable {
    public AudioClip doorCloseSound;
    public AudioClip doorOpenSound;

    public Animator doorAnimator;
    public bool openFromStart = false;

    void Start() {
        if(openFromStart)
            doorAnimator.SetTrigger("Interact");
    }

    public void PlayOpenSound() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = doorOpenSound;
        audio.Play();
    }

    public void PlayCloseSound() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = doorCloseSound;
        audio.Play();
    }
    public override void Interact() {
        //doorAnimator.SetTrigger("Interact");
    }
}
