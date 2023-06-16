using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private GameObject[] tracks;
    
    private Color lightGreen = new Color(0f, 1f, 0.1f, 1f);
    private Color magenta = new Color(0.8f, 0f, 0.6f, 1f);

    private float pointTime = 10.0f;

    public void DoublePointsModeOn() {
        pointTime = 10.0f;
        Debug.Log("Enable");
        doublePoints = true;
        RenderSettings.fogColor = lightGreen;
        foreach(GameObject track in tracks) {
            Animator trackAnimator = track.GetComponent<Animator>();
            trackAnimator.SetBool("doublePoints", true);
        }
    }
        
    public void DoublePointsModeOff() {
        Debug.Log("Disable");
        doublePoints = false;
        RenderSettings.fogColor = magenta;
        foreach(GameObject track in tracks) {
            Animator trackAnimator = track.GetComponent<Animator>();
            trackAnimator.SetBool("doublePoints", false);
        }
    }

    public void Start() {
        hiScoreText = hiScoreMessage.GetComponent<TMP_Text>();
        scoreText = scoreMessage.GetComponent<TMP_Text>();
        tracks = GameObject.FindGameObjectsWithTag("Track");
    }

    void Update() {
        pointTime -= Time.deltaTime;
        if(doublePoints && pointTime <= 0) {
            DoublePointsModeOff();
        }
    }
}
