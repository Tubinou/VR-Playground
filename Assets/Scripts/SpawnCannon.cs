using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCannon : MonoBehaviour
{
    [SerializeField] Slider PowerSlider;
    [SerializeField] Slider MassSlider;
    [SerializeField] Slider SizeSlider;
    [SerializeField] Text PowerText;
    [SerializeField] Text MassText;
    [SerializeField] Text SizeText;    
    [SerializeField] Transform SpawnPosition;
    [SerializeField] GameObject SpawnPrefab;
    [SerializeField] AudioClip[] cannonShotAudioClips;

    AudioSource audioSource;

    public float currentForce = 20;
    public string currentText = $"Power: 20/100";

    public float currentMass = 10f;
    public float currentSize = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!PowerSlider)
        {
            return;
        }        

        currentForce = PowerSlider.value;        

        if(!PowerText)
        {
            return;
        }

        currentText = $"Power: {currentForce}/{PowerSlider.maxValue}";
        PowerText.text = currentText;

        if(!MassSlider)
        {
            return;
        }

        currentMass = MassSlider.value;

        if(!MassSlider)
        {
            return;
        }

        MassText.text = $"Current mass: {currentMass}/{MassSlider.maxValue}";

        if(!SizeSlider)
        {
            return;
        }

        currentSize = SizeSlider.value;

        if(!SizeText)
        {
            return;
        }

        SizeText.text = $"Current size: {currentSize} / {SizeSlider.maxValue}";                
    }

    public void SpawnSomething()
    {
        GameObject projectile = Instantiate(SpawnPrefab, SpawnPosition);
        projectile.transform.rotation = transform.rotation;
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        if(!projectileRB)
        {
            return;
        }

        if(SizeSlider)
        {
            projectile.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
        }

        if(MassSlider)
        {
            projectileRB.mass = currentMass;
        }

        PlayCannonShotClip();
        projectileRB.AddForce(transform.up * currentForce, ForceMode.Impulse);
    }

    void PlayCannonShotClip(){
        audioSource.clip = cannonShotAudioClips[UnityEngine.Random.Range(0, cannonShotAudioClips.Length)];
        audioSource.Play();
    }
}
