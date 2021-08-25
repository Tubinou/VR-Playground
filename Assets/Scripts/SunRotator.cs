using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotator : MonoBehaviour
{
    public Vector3 rotationVector = new Vector3(1f, 0f, 0f);
    public bool isRotating = true;
    Light sunSource;

    void Start()
    {
        sunSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotating)
        {
            transform.Rotate(rotationVector);
        }
    }
}
