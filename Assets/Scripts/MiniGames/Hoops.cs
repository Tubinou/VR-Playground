using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hoops : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] int scoreThreshold = 10;
    [SerializeField] GameEvent thresholdEvent;

    public int score;

    void Start()
    {
        scoreText.text = $"Let's play hoops!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Hoops"))
        {
            score += 1;
            scoreText.text = $"Sweet! {score} / {scoreThreshold}";
        }

        if(score >= scoreThreshold)
        {
            thresholdEvent?.InvokeEvent();
        }
    }
}
