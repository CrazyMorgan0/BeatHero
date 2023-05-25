using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public BeatSpawner beatSpawner;
    public GameObject pointsObject;

    public void StartGame() {
        beatSpawner.soundManager.PlayMusic();
    }

    public void EnableText(bool enable) {
        pointsObject.SetActive(enable);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        EnableText(false);
        //beatSpawner.SpawnBeat();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
