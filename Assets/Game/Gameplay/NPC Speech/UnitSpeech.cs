using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(AudioSource))]
public class UnitSpeech : MonoBehaviour {
    public GameObject speechBubblePrefab;
    public float speechDuration = 3;

    public AIMood HappyMood;
    public AIMood SadMood;
    public AIMood PointerMood;
    public AIMood AngryMood;
    public AIMood AggressiveMood;
    public AIMood BoredMood;
    public AIMood HelpfulMood;
    public AIMood SurprisedMood;
    public Dictionary<Mood, AIMood> moodList;

    private AudioSource audioSource;
    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.spatialBlend = 1;

        moodList = new Dictionary<Mood, AIMood>();
        moodList.Add(Mood.None, null);
        moodList.Add(Mood.Happy, HappyMood);
        moodList.Add(Mood.Angry, AngryMood);
        moodList.Add(Mood.Point, PointerMood);
        moodList.Add(Mood.Aggressive, AggressiveMood);
        moodList.Add(Mood.Sad, SadMood);
        moodList.Add(Mood.Bored, BoredMood);
        moodList.Add(Mood.Helpful, HelpfulMood);
        moodList.Add(Mood.Surprised, SurprisedMood);
    }

    private void PlayAudio(AudioClip sound) {
        audioSource.clip = sound;
        audioSource.Play();
    }

    public void Speak(Mood mood) {
        if (mood == Mood.None)
            return;

        if (GetComponentInChildren<SpeechBubble>())
            Destroy(GetComponentInChildren<SpeechBubble>().gameObject);

        GameObject go = (GameObject)Instantiate(speechBubblePrefab, transform.position + Vector3.up * 3f, Quaternion.LookRotation(-Camera.main.transform.up, Vector3.up));
        SpeechBubble sb = go.GetComponent<SpeechBubble>();

        sb.SetImage(moodList[mood].moodSprite);
        sb.lifeTime = speechDuration;
        go.transform.SetParent(transform, true);

        if (moodList[mood].voice != null)
            PlayAudio(moodList[mood].voice);

    }
}
