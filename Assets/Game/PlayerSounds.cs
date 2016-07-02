using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

    public AudioClip walkSound;

	public void PlayWalkSound() {
        GetComponent<AudioSource>().clip = walkSound;
        GetComponent<AudioSource>().Play();
    }
        
}
