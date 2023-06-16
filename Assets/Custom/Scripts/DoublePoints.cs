using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    private ScoreTracker scoreTracker;
    void Start() {
        scoreTracker = GameObject.FindWithTag("Player").GetComponent<ScoreTracker>();
        scoreTracker.DoublePointsModeOn();
    }
}
