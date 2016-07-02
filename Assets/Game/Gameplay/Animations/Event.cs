using UnityEngine;
using System.Collections;

[System.Serializable]
public class AIEvent {
    public float startDelay = 0;
    [Range(1, 20)]
    public float moveSpeed = 5;
    public Transform waypoint;
    public Mood mood;
    public AnimationEnum animation;
}
