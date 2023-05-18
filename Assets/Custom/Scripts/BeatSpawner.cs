using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    //List of beat prefabs
    public GameObject[] beats;

    //List of spawn points
    private List<Transform> spawnPoints = new List<Transform>();

    //The songs BPM
    public float beatsPerMinute = 0;

    //The ratio of player beats compared to song beats 
    int beatInterval = 4;

    //Timer the beat spawning is based on
    private float timer;

    void Start() {
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("Spawn");
        foreach(GameObject spawnObject in spawnObjects) {
            spawnPoints.Add(spawnObject.transform);
        }
    }

    //Spawns a beat at a spawn point
    void SpawnBeat() {
        //TODO Currently spawns a random beat at a random spawn point, not very fun
        Instantiate(beats[Random.Range(0, beats.Length)], spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        float secondsPerBeat = 60 / beatsPerMinute;
        if(timer > secondsPerBeat * beatInterval)
        {
            SpawnBeat();
            //Reset timer
            timer -= secondsPerBeat * beatInterval;
        }
        //Increment timer
        timer += Time.deltaTime;
    }
}
