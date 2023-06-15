using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SafetyMessage : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject player;
    private ToggleMenu menuScript;

    private void Director_Played(PlayableDirector obj) {
        menuScript.HideMenu();
    }

    private void Director_Stopped(PlayableDirector obj) {
        menuScript.ShowMenu();
    }

    public void StartTimeline() {
        director.Play();
    }

    public void Awake() {
        menuScript = player.GetComponent<ToggleMenu>();
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }
}
