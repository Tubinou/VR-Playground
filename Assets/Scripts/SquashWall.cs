using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquashWall : MonoBehaviour
{
    [SerializeField] int scoreThreshold = 10;
    [SerializeField] GameEvent thresholdEvent;
    [SerializeField] Text ScoreText;
    [SerializeField] float gameLength = 60f;

    public string currentText = $"Max bounces: 0";
    public float timer;
    public int currentScore;
    public int bestScore;
    public bool gameOn = false;

    bool isDone = false;

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
                Debug.Log("point");
                currentScore += 1;
                if(currentScore >= scoreThreshold)
                {
                    ThresholdReached();
                }
                return;
            }

            Debug.Log("game started");
            StartSquashGame();
        }
    }

    public void StartSquashGame()
    {
        if(!ScoreText)
        {
            return;
        }

        gameOn = true;
        timer = gameLength;
        currentScore = 1;
    }

    public void ThresholdReached()
    {
        if(!isDone)
        {
            thresholdEvent.InvokeEvent();
            isDone = true;
        }        
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
