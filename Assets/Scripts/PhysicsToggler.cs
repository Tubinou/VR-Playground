using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsToggler : MonoBehaviour
{
    Rigidbody rb;
    public bool doOnce = false;
    MeshRenderer myRenderer;
    
    private void Start() 
    {
        myRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    public void TogglePhysics()
    {
        rb.isKinematic = false;
        myRenderer.material.color = new Color(myRenderer.material.color.r,myRenderer.material.color.g,myRenderer.material.color.b,myRenderer.material.color.a / 10f);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("WreckingBall")){
            rb.isKinematic = false;            
        }
    }
}
