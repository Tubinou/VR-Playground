using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip winClip;

    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void playWinClip(){
        audioSource.clip = winClip;
        audioSource.Play();
    }
}
