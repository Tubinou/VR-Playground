using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquashWall : MonoBehaviour
{
    [SerializeField] int scoreThreshold = 10;
    [SerializeField] GameEvent squashGameCompleted;
    [SerializeField] Text ScoreText;
    [SerializeField] float gameLength = 60f;
    [SerializeField] AudioClip[] SquashHitClips;

    bool isDone = false;
    AudioSource audioSource;

    public string currentText = $"Max bounces: 0";
    public float timer;
    public int currentScore;
    public int bestScore;
    public bool gameOn = false;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        if(gameOn)
        {
            ScoreText.text = $"{timer.ToString("{#.00}")} seconds left!\nCurrent bounces: {currentScore} / {scoreThreshold}";
            timer -= Time.deltaTime;            
            if(timer <= 0)
            {
                StopSquashGame();
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.CompareTag("Catalyst"))
        {
            if(gameOn)
            {
                currentScore += 1;
                PlaySquashHitClip();

                if(!isDone && currentScore >= scoreThreshold)
                {
                    ThresholdReached();
                }

                return;
            }

            StartSquashGame();
        }
    }

    void PlaySquashHitClip(){
        AudioClip currentClip = SquashHitClips[UnityEngine.Random.Range(0, SquashHitClips.Length)];
        audioSource.clip = currentClip;
        audioSource.Play();
    }

    public void StartSquashGame()
    {
        if(!ScoreText)
        {
            return;
        }

        gameOn = true;
        timer = gameLength;
        PlaySquashHitClip();
        currentScore = 1;
    }

    public void ThresholdReached()
    {
        isDone = true;
        squashGameCompleted.InvokeEvent();
    }

    public void StopSquashGame()
    {
        gameOn = false;

        if(currentScore >= bestScore)
        {
            bestScore = currentScore;
            ScoreText.text = $"New highscore! Your record is: {currentScore} ";
            return;
        }

        ScoreText.text = $"Time's up! you managed {currentScore} bounces!\n Best score is {bestScore}";
        currentScore = 0;
        timer = gameLength;
    }
}
