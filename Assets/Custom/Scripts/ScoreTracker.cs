using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int score = 0;
    private bool doublePoints = false;

    public void SetDoublePoints(bool setter) {
        doublePoints = setter;
    }

    public void UpdateScore(int value) {
        if(value > 0 && doublePoints) {
            value = value * 2;
        }
        score += value;
    }
}
