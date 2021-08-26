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
    [SerializeField] int maxActiveDolls = 3;
    [SerializeField] GameObject[] WhackDolls;
    [SerializeField] GameObject[] WhackSlots;

    int activeDolls = 0;

    public string currentText = $"Max hits: 0";
    public float timer;
    public int currentScore;
    public int bestScore;
    public bool gameOn = false;
    public bool isDone = false;
    GameObject doll;

    GameObject CurrentWhackable;
    List<Vector3> OriginalPositions = new List<Vector3>();

    public void ActivateRandomWhackDoll(){
        if(activeDolls < maxActiveDolls){
            int randomPrefab = (int)UnityEngine.Random.Range(0f, WhackDolls.Length);
            int randomSlot = (int)UnityEngine.Random.Range(0f, WhackSlots.Length);
            Transform slot = WhackSlots[randomSlot].transform;
            GameObject newDoll = Instantiate(WhackDolls[randomPrefab], slot.position, Quaternion.identity);
            activeDolls++;
        }
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
            StopWhacking();
        }        
    }

    public void OnSuccessFulHit() 
    {
        if(gameOn){
            currentScore += 1;
            activeDolls--;
            Invoke("ActivateRandomWhackDoll", 0.75f);
        }                
    }

    public void OnDollEscaped(){
        if(gameOn){
            activeDolls--;
            Invoke("ActivateRandomWhackDoll", 0.5f);
        }                
    }

    public void StartWhacking(){
        if(!ScoreText)
        {
            return;
        }

        if(!gameOn){
            gameOn = true;
            timer = gameLength;
            currentScore = 0;
            ActivateRandomWhackDoll();
        }        
    }

    public void StopWhacking()
    {
        gameOn = false;

        if(currentScore >= bestScore){
            bestScore = currentScore;
            ScoreText.text = $"New highscore! Your record is: {currentScore} ";
        }

        else{
            ScoreText.text = $"Good round! you managed {currentScore} bounces!\n Best score is {bestScore}";
        }

        currentScore = 0;
        timer = gameLength;
    }
}
