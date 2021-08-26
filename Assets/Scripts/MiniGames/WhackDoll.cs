using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackDoll : MonoBehaviour
{
    [SerializeField] Vector3 moveVector = new Vector3(0f, 0.1f, 0f);    
    [SerializeField] GameEvent WhackFailed;

    public bool inGame;
    public float maxDistance = 0.9f;
    public float minDistance = 0.1f;
    
    Vector3 originalPosition;
    Quaternion originalRotation;
    Rigidbody myrb;
    bool hasFlipped = false;

    private void Awake() 
    {
        inGame = true;
        myrb = GetComponent<Rigidbody>();
        myrb.useGravity = false;
        originalPosition = transform.position;        
        originalRotation = transform.rotation;
    }

    private void FixedUpdate() 
    {
        if(inGame){
            if(float.IsNaN(maxDistance))
            {
                return;
            }
            
            Vector3 positionVector = transform.position - originalPosition;

            if(!hasFlipped)
            {            
                if(positionVector.magnitude >= maxDistance)
                {
                    moveVector *= -1;
                    hasFlipped = !hasFlipped;
                }
            }

            if(hasFlipped)
            {
                if(positionVector.magnitude <= minDistance)
                {
                    WhackFailed.InvokeEvent();
                    Destroy(this.gameObject);
                }
            }        
            myrb.position = myrb.position + moveVector;
            transform.Translate(moveVector);
        }        
    }
}
