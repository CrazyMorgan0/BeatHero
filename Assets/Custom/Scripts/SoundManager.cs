using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

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
    private float positionInSecs;

    //Time when music starts playing
    private float dspSongTime;

    //Plays the music for the game
    public void PlayMusic()
    {
        audioSource.PlayOneShot(music);    
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        secsPerBeat = 60f / BPM;
        //Record time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
    }

    //Refresh position variables by checking how long the song has been playing
    void Update() {
        positionInSecs = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        positionInBeats = positionInSecs / secsPerBeat;
    }
}
