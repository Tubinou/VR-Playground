using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableBat : MonoBehaviour
{
    [SerializeField] AudioClip[] collisionClips;
    public bool isHeld = false;
    AudioSource audioSource;

    public void onGrabbed(){
        isHeld = true;
    }

    public void onReleased(){
        isHeld = false;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

private void OnCollisionEnter(Collision other) {
    if(isHeld && !audioSource.isPlaying && !other.collider.CompareTag("Socket")){
        audioSource.clip = collisionClips[UnityEngine.Random.Range(0, collisionClips.Length)];
        audioSource.Play();
    }
}
}
