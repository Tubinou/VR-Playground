using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hoops : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] int scoreThreshold = 10;
    [SerializeField] GameEvent thresholdEvent;
    [SerializeField] AudioClip[] successfulHoopClips;

    AudioSource audioSource;
    public int score;

    void Start()
    {
        scoreText.text = $"Let's play\nhoops!";
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySuccessfullHoopClip(){
        audioSource.clip = successfulHoopClips[UnityEngine.Random.Range(0, successfulHoopClips.Length)];
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Hoops"))
        {
            PlaySuccessfullHoopClip();
            score += 1;            
            scoreText.text = $"Sweet! {score} / {scoreThreshold}";
        }

        if(score >= scoreThreshold)
        {
            thresholdEvent.InvokeEvent();
        }
    }
}
