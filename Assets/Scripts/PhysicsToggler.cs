using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsToggler : MonoBehaviour
{
    Rigidbody rb;
    public bool doOnce = false;
    
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    public void TogglePhysics()
    {
        rb.isKinematic = false;
    }
}
