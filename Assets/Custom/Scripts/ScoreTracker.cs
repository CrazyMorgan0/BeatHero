using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public GameObject doubleMessage;
    public GameObject scoreMessage;
    private TMP_Text scoreText;
    public GameObject hiScoreMessage;
    private TMP_Text hiScoreText;
    public int score = 0;
    public int hiScore = 0;

    private bool doublePoints = false;

    public void SetDoublePoints(bool setter) {
        doubleMessage.SetActive(setter);
        doublePoints = setter;
    }

    public void UpdateScore(int value) {
        if(value > 0 && doublePoints) {
            value = value * 2;
        }
        score += value;
        scoreText.text = score.ToString();
        if(score > hiScore) {
            hiScore = score;
            hiScoreText.text = hiScore.ToString();
        }
    }

    public void ResetScore() {
        score = 0;
    }

    public void ShowScore() {
        scoreMessage.SetActive(true);
    }

    public void HideScore() {
        scoreMessage.SetActive(false);
    }

    public void Start() {
        hiScoreText = hiScoreMessage.GetComponent<TMP_Text>();
        scoreText = scoreMessage.GetComponent<TMP_Text>();
    }
}
