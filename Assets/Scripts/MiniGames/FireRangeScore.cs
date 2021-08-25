using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireRangeScore : MonoBehaviour
{
    [SerializeField] int thresholdScore;
    [SerializeField] GameEvent thresholdEvent;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] float gameTime = 30f;
    public int score = 0;
    public bool gameOn = false;

    float timer;

    void Start()
    {
        timer = gameTime;
        scoreText.text = $"Fire the cannon\nto start";
    }

    private void Update() {
        if(gameOn)
        {
            timer -= Time.deltaTime;
            string timerString = timer.ToString("F2");
            scoreText.text = $"{timerString} left,\n Score {score} / {thresholdScore}";

            if(score >= thresholdScore){
                thresholdEvent.InvokeEvent();
            }

            if(timer <= 0)
            {
                stopGame();
            }            
        }
    }

    public void startGame()
    {
        if(!gameOn)
        {
            score = 0;
            timer = gameTime;
            gameOn = true;
        }        
    }

    public void stopGame()
    {
        gameOn = false;
        scoreText.text = $"Time's up!,\n Score {score}";
    }

    public void UpdateScore(int scoreDelta)
    {
        if(gameOn)
        {
            score += scoreDelta;
        }
    }
}
