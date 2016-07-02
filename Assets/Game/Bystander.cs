using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bystander : MonoBehaviour {

    public Animator anim;
    private int animNumber = 0;

    public List<Mood> RandomMoodList;

    void Awake() {
        animNumber = Random.Range(0, 5);
        anim.SetInteger("Idleanim", animNumber);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GetComponent<UnitSpeech>().Speak(RandomMoodList[Random.Range(0, RandomMoodList.Count)]);

            if (Random.Range(0, 2) == 0)
                anim.SetTrigger("Taunt");
            else
                anim.SetTrigger("Point");
        }
    }
}
