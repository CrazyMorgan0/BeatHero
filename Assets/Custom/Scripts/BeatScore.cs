using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScore : MonoBehaviour
{
    private GameObject player;
    private ScoreTracker scoreTracker;
    private SliceHaptic sliceHaptic;
    public int score = 0;
    private GameObject ninja;
    private NinjaAnimScript ninjaAnimator;

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Saber") {
            ninjaAnimator.Slash();
            scoreTracker.UpdateScore(score);
            if(other.gameObject.name == "LeftBlade") {
                sliceHaptic.LeftHapticOnScore(Mathf.Abs(score));
            } else if(other.gameObject.name == "RightBlade") {
                sliceHaptic.RightHapticOnScore(Mathf.Abs(score));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ninja = GameObject.FindWithTag("Ninja");
        ninjaAnimator = ninja.GetComponent<NinjaAnimScript>();
        player = GameObject.FindWithTag("Player");
        sliceHaptic = player.GetComponent<SliceHaptic>();
        scoreTracker = player.GetComponent<ScoreTracker>();
    }
}
