using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoublePoints : MonoBehaviour
{
    private BeatSpawner spawnScript;
    private ScoreTracker scoreScript;
    private GameObject[] tracks;
    
    private Color lightGreen = new Color(0f, 1f, 0.1f, 1f);
    private Color magenta = new Color(0.8f, 0f, 0.6f, 1f);

    IEnumerator DoublePointsMode() {
        scoreScript.SetDoublePoints(true);
        spawnScript.EnableText(true);
        RenderSettings.fogColor = lightGreen;
        foreach(GameObject track in tracks) {
            Animator trackAnimator = track.GetComponent<Animator>();
            trackAnimator.SetBool("doublePoints", true);
        }
        yield return new WaitForSeconds(10f);
        scoreScript.SetDoublePoints(false);
        spawnScript.EnableText(false);
        RenderSettings.fogColor = magenta;
        foreach(GameObject track in tracks) {
            Animator trackAnimator = track.GetComponent<Animator>();
            trackAnimator.SetBool("doublePoints", false);
        }
    }

    public void ActivateDoublePoints() {
        StartCoroutine(DoublePointsMode());
    }

    // Start is called before the first frame update
    void Start()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");
        spawnScript = GameObject.FindWithTag("Spawner").GetComponent<BeatSpawner>();
        scoreScript = GameObject.FindWithTag("Player").GetComponent<ScoreTracker>();
    }
}
