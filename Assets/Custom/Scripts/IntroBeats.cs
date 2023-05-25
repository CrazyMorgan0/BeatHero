using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBeats : MonoBehaviour
{
    [SerializeField]
    private BeatSpawner beatSpawner;

    public void SpawnerBeat() {
        beatSpawner.SpawnBeat();
    }

    public void SpawnerBar() {
        beatSpawner.SpawnBar();
    }
}
