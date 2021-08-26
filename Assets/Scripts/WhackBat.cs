using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackBat : MonoBehaviour
{
    [SerializeField] GameObject PoofPrefab;
    [SerializeField] GameEvent WhackScoreUp;
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
    if(isHeld && other.collider.CompareTag("Whackamole")){
        if(other.gameObject.GetComponent<WhackDoll>().inGame){
            other.gameObject.GetComponent<WhackDoll>().inGame = false;
            // Destroy(other.gameObject);
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;            
            GameObject PoofEffect = Instantiate(PoofPrefab, other.transform.position, Quaternion.identity);
            Destroy(PoofEffect, 5f);

            audioSource.clip = collisionClips[UnityEngine.Random.Range(0, collisionClips.Length)];
            audioSource.Play();

            WhackScoreUp.InvokeEvent();
        }        
    }
}
}
