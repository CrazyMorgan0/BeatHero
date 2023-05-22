using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip music;

    [SerializeField]
    private float firstBeatOffset;

    public float BPM;

    public float positionInBeats;

    private float secsPerBeat;

    private float positionInSecs;

    //Time when music starts playing
    private float dspSongTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        secsPerBeat = 60f / BPM;
        //Record time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        PlayMusic();
    }

    void Update() {
        positionInSecs = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        positionInBeats = songPosition / secsPerBeat;
    }

    //Plays the music for the game
    public void PlayMusic()
    {
        audioSource.PlayOneShot(music);    
    }
}
