using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    //List of beat prefabs
    public GameObject[] beats;

    //List of spawn points
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private Transform midPoint;
    [SerializeField]
    private Transform bottomPoint;

    public GameObject pointsObject;

    private int beatCount;

    public void SpawnBar() {
        Instantiate(beats[1], midPoint);
        Instantiate(beats[2], bottomPoint);
    }

    public void StartGame() {
        soundManager.PlayMusic();
    }

    public void EnableText(bool enable) {
        pointsObject.SetActive(enable);
    }

    //Plays the song and tracks the song position
    public SoundManager soundManager;

    //The ratio of player beats compared to song beats 
    private float beatInterval = 0.0f;

    //Spawns a beat at a spawn point
    public void SpawnBeat() {
        Instantiate(beats[0], spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }

    //Collect all spawnpoints and unpack lists
    void Start() {
        EnableText(false);
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("Spawn");
        foreach(GameObject spawnObject in spawnObjects) {
            spawnPoints.Add(spawnObject.transform);
        }
    }

    //Check if it's time to spawn a beat
    void Update()
    {
        //Spawns a beat every beat interval
        if(soundManager.positionInBeats > beatInterval)
        {
            //Spawn a bar instead of a beat every 8 beats 
            if(beatCount < 8) {
                SpawnBeat();
                beatCount++;
            } else {
                SpawnBar();
                beatCount = 0;
            }
            //Update the interval for the next beat
            beatInterval += 8.0f;
        }
    }
}
