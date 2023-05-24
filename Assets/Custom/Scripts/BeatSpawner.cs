using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    //List of beat prefabs
    public GameObject[] beats;

    //List of spawn points
    private List<Transform> spawnPoints = new List<Transform>();
    

    //Plays the song and tracks the song position
    public SoundManager soundManager;

    //The ratio of player beats compared to song beats 
    private float beatInterval = 0.0f;

    //Spawns a beat at a spawn point
    public void SpawnBeat() {
        //TODO Currently spawns a random beat at a random spawn point, not very fun
        Instantiate(beats[Random.Range(0, beats.Length)], spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }

    //Collect all spawnpoints
    void Start() {
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("Spawn");
        foreach(GameObject spawnObject in spawnObjects) {
            spawnPoints.Add(spawnObject.transform);
        }
        SpawnBeat();
    }

    //Check if it's time to spawn a beat
    void Update()
    {
        //Spawns a beat every beat interval
        if(soundManager.positionInBeats >= beatInterval)
        {
            SpawnBeat();
            //Update the interval for the next beat
            beatInterval += 8.0f;
        }
    }
}
