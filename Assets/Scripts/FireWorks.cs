using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorks : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionPS;
    [SerializeField] TrailRenderer ballTrail;
    [SerializeField] float timeToLive = 3f;
    [SerializeField] AudioClip fireWorkExplosionClip;

    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        float ttl = explosionPS.emission.GetBurst(0).time;
        Invoke("PlayBurstSound", ttl);

        Destroy(ballTrail.gameObject, ttl);
        Destroy(this.gameObject, timeToLive);
    }

    void PlayBurstSound()
    {
        audioSource.clip = fireWorkExplosionClip;
        audioSource.Play();
    }
}
