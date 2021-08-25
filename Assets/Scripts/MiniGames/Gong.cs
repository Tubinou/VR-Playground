using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gong : MonoBehaviour
{
    [SerializeField] LineRenderer RightHandle;
    [SerializeField] LineRenderer LeftHandle;
    [SerializeField] GameEvent StageWonEvent;
    public AudioClip gongClip;

    AudioSource audioSource;

    bool isDone = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponents<LineRenderer>();
        LeftHandle.SetPosition(0, this.transform.position);
        RightHandle.SetPosition(0, this.transform.position);
        RightHandle.SetPosition(1, RightHandle.transform.position);
        LeftHandle.SetPosition(1, LeftHandle.transform.position);
    }

    void Update()
    {
        RightHandle.SetPosition(0, this.transform.position);
        LeftHandle.SetPosition(0, this.transform.position);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("WreckingBall")){
            PlayGong();
        }
    }

    void PlayGong(){
        if(!isDone){
            isDone = true;
            audioSource.clip = gongClip;
            audioSource.Play();
            StageWonEvent?.InvokeEvent();
        }
    }
}
