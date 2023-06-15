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
    private Transform barPoint;
    [SerializeField]
    private Transform bottomPoint;
    private GameObject ninja;
    private NinjaAnimScript ninjaAnimator;

    private int beatCount;

    //Plays the song and tracks the song position
    public SoundManager soundManager;

    //The ratio of player beats compared to song beats 
    private float beatInterval = 0.0f;

    public void SpawnBar() {
        ninjaAnimator.Crouch();
        Instantiate(beats[1], barPoint);
        Instantiate(beats[2], bottomPoint);
    }

    public void StartGame() {
        soundManager.PlayMusic();
    }

    //Spawns a beat at a spawn point
    public void SpawnBeat() {
        Instantiate(beats[0], spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }

    //Collect all spawnpoints and unpack lists
    void Start() {
        ninja = GameObject.FindWithTag("Ninja");
        ninjaAnimator = ninja.GetComponent<NinjaAnimScript>();
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
            if(beatCount < 7) {
                SpawnBeat();
                beatCount++;
            } else {
                SpawnBar();
                beatCount = 0;
            }
            //Update the interval for the next beat
            beatInterval += 4.0f;
        }
    }
}
