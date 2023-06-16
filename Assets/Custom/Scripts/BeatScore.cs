using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScore : MonoBehaviour
{
    private GameObject player;
    private ScoreTracker scoreTracker;
    private SliceHaptic sliceHaptic;
    [SerializeField]
    private List<AudioClip> beatSound;
    //Plays the song and tracks the song position
    private SoundManager soundManager;
    public int score = 0;
    private NinjaAnimScript ninjaAnimator;

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Saber") {
            ninjaAnimator.Slash();
            soundManager.PlayBeatSound(beatSound);
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
        ninjaAnimator = GameObject.FindWithTag("Ninja").GetComponent<NinjaAnimScript>();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        player = GameObject.FindWithTag("Player");
        sliceHaptic = player.GetComponent<SliceHaptic>();
        scoreTracker = player.GetComponent<ScoreTracker>();
    }
}
