using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    //TODO Currently plays music on Startup
    //Plays the music for the game
    public void PlayMusic()
    {
        audioSource.PlayOneShot(music);    
    }
}
