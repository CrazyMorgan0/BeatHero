using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private GameObject player;
    private ToggleMenu menuScript;
    private AudioSource audioSource;
    private GameObject ninja;
    private NinjaAnimScript ninjaAnimator;

    private bool playing = false;

    //Music clip for the game
    [SerializeField]
    private AudioClip music;

    //Offset for when the music starts playing
    [SerializeField]
    private float firstBeatOffset;

    //Beats per minute of the song
    public float BPM;

    //Track current position of song in beats
    public float positionInBeats;

    //How many seconds are within a beat
    private float secsPerBeat;
    
    //Track current position of song in beats
    private float positionInSecs = 0;

    //Time when music starts playing
    private float dspSongTime = 0;

    //Plays the music for the game
    public void PlayMusic()
    {
        menuScript.HideMenu();
        playing = true;
        audioSource.PlayOneShot(music);
        dspSongTime = (float)AudioSettings.dspTime;  
    }

    public void PlayBeatSound(AudioClip[] sounds) {
        audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Count())]);
    }
    
    public void PlayBeatSound(AudioClip sound) {
        audioSource.PlayOneShot(sound);
    }

    // Start is called before the first frame update
    void Start()
    {
        ninja = GameObject.FindWithTag("Ninja");
        ninjaAnimator = ninja.GetComponent<NinjaAnimScript>();
        menuScript = player.GetComponent<ToggleMenu>();
        audioSource = GetComponent<AudioSource>();
        secsPerBeat = 60f / BPM;
    }

    //Refresh position variables by checking how long the song has been playing
    void Update() {
        if(playing) {
            positionInSecs = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
            positionInBeats = positionInSecs / secsPerBeat;
        } if(positionInSecs >= 160) {
            playing = false;
            menuScript.ShowMenu();
        }
    }
}
