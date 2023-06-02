using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroBeats : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject controlPanel;
    [SerializeField]
    private BeatSpawner beatSpawner;

    public void SpawnerBeat() {
        beatSpawner.SpawnBeat();
    }

    public void SpawnerBar() {
        beatSpawner.SpawnBar();
    }

    private void Director_Played(PlayableDirector obj) {
        controlPanel.SetActive(false);
    }

    private void Director_Stopped(PlayableDirector obj) {
        controlPanel.SetActive(true);
    }

    public void StartTimeline() {
        director.Play();
    }

    public void Awake() {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
//        director.stopped += Director_Stopped;
    }
}
