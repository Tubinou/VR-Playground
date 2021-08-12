using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackDoll : MonoBehaviour
{
    [SerializeField] GameObject WhatDollsPrefab;
    [SerializeField] GameEvent WhackScoreUp;
    [SerializeField] Transform Top;
    [SerializeField] Transform Bottom;
    public bool isMoving = false;
    public bool inGame = true;

    Transform originalTransform;
    public float speed = 0.2f;
    Rigidbody myrb;

    private void Start() 
    {
        isMoving = false;
        originalTransform = transform;
        myrb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {        
        if(isMoving && other.CompareTag("WhackHammer"))
        {
            isMoving = false;
            GameObject newDoll = Instantiate(WhatDollsPrefab, originalTransform);
            WhackDoll newWhackDoll = newDoll.GetComponent<WhackDoll>();

            if(newWhackDoll)
            {
                newWhackDoll.Top = Top;
                newWhackDoll.Bottom = Bottom;
            }
            myrb.isKinematic = false;
            WhackScoreUp.InvokeEvent();
        }
    }

    private void FixedUpdate() 
    {
        if(!isMoving)
        {
            return;
        }

        if(transform.position.y <= Bottom.position.y)
        {
            speed *= -1;
            transform.position = originalTransform.position;
            isMoving = false;
        }
        
        if(transform.position.y >= Top.position.y)
        {
            speed *= -1;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);     
    }
}
