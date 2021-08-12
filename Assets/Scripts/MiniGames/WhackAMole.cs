using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhackAMole : MonoBehaviour
{
    [SerializeField] int ThresholdScore = 10;
    [SerializeField] GameEvent ThresholdEvent;
    [SerializeField] Text ScoreText;
    [SerializeField] float gameLength = 60f;
    [SerializeField] int ActiveDollsNum = 2;
    [SerializeField] WhackDoll[] WhackDolls;

    public string currentText = $"Max hits: 0";
    public float timer;
    public int currentScore;
    public int bestScore;
    public bool gameOn = false;
    public bool isDone = false;
    GameObject doll;

    int currentActiveDollNum = 0;
    GameObject CurrentWhackable;
    List<Vector3> OriginalPositions = new List<Vector3>();

    private void Start() {
        for(int i = 0; i <= WhackDolls.Length -1; i++)
        {
            OriginalPositions.Add(WhackDolls[i].transform.position);
        }
        doll = WhackDolls[0].gameObject;
    }

    private void Update() 
    {
        if(gameOn)
        {
            ScoreText.text = $"{timer.ToString("{#.00}")} seconds left! You scored {currentScore} / {ThresholdScore} hits";
            timer -= Time.deltaTime;            

            if(timer <= 0)
            {
                StopWhacking();
                return;
            }

            foreach(WhackDoll whackable in WhackDolls)
            {
                if(whackable.inGame == false)
                {
                    GameObject newDoll = Instantiate(doll, doll.transform);
                    WhackDoll whackdoll = newDoll.GetComponent<WhackDoll>();
                    whackdoll.isMoving = true;
                }

                currentActiveDollNum = 0;
                if(whackable.isMoving)
                {
                    currentActiveDollNum += 1;                    
                }

                else if(currentActiveDollNum < ActiveDollsNum)
                {
                    whackable.isMoving = true;
                }
            }

            if(currentScore >= ThresholdScore)
            {
                GameWon();
            }
        }
    }

    public void GameWon()
    {
        gameOn = false;
        if(!isDone)
        {
            ThresholdEvent?.InvokeEvent();
            isDone = true;
        }

        ScoreText.text = $"Good! Now go and break some walls";        
    }

    public void OnSuccessFulHit() 
    {
        currentScore += 1;
    }

    public void StartWhacking()
    {
        if(!ScoreText)
        {
            return;
        }

        gameOn = true;
        timer = gameLength;
        currentScore = 0;
        Debug.Log($"WhackAMole game started");
    }

    public void StopWhacking()
    {
        gameOn = false;

        if(currentScore >= bestScore)
        {
            bestScore = currentScore;
            ScoreText.text = $"New highscore! Your record is: {currentScore} ";
            Debug.Log($"WhackAMole game highscore");
            return;
        }

        ScoreText.text = $"Time's up! you managed {currentScore} bounces!\n Best score is {bestScore}";
        currentScore = 0;
        timer = gameLength;
        Debug.Log($"WhackAMole game Stopped");
    }
}
