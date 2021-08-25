using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] TextMeshPro targetText;
    [SerializeField] AudioClip[] targetHitClips;

    AudioSource audioSource;

    FireRangeScore scoreBoard;
    string scoreString;
    float timer;

    [SerializeField] float initialTimer = 2f;

    void Start()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("FireRange").GetComponent<FireRangeScore>();
        targetText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(targetText.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                targetText.gameObject.SetActive(false);
            }
        }
    }
    
    private void OnCollisionEnter(Collision other) {            
            if(scoreBoard.gameOn && other.collider.CompareTag("Catalyst") && other.GetContact(0).thisCollider.name == "Outer")
            {
                targetText.gameObject.SetActive(true);
                targetText.text = $"Outer frame,\n1 point";
                timer = initialTimer;

                scoreBoard.UpdateScore(1);
                PlayTargetHit(1);
            }

            else if(scoreBoard.gameOn && other.collider.CompareTag("Catalyst") && other.GetContact(0).thisCollider.name == "Middle")
            {
                targetText.gameObject.SetActive(true);
                targetText.text = $"Inner frame,\n2 points!";
                timer = initialTimer;

                scoreBoard.UpdateScore(2);
                PlayTargetHit(2);
            }

            else if(scoreBoard.gameOn && other.collider.CompareTag("Catalyst") && other.GetContact(0).thisCollider.name == "BullsEye")
            {
                targetText.gameObject.SetActive(true);
                targetText.text = $"Bull's eye!\n3 point~! <3";
                timer = initialTimer;

                scoreBoard.UpdateScore(3);
                PlayTargetHit(3);
            }
    }

    void PlayTargetHit(int points){
        audioSource.clip = targetHitClips[points - 1];
        audioSource.Play();
    }
}
