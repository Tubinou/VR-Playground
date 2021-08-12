using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField] Vector3 moveVector;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;
    [SerializeField] Transform OuterTarget;

    Vector3 originalPosition;
    Vector3 positionVector;
    bool hasFlipped;
    LineRenderer targetLine;

    void Start()
    {
        originalPosition = transform.position;
        targetLine = GetComponent<LineRenderer>();
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, OuterTarget.position);
    }

    void Update()
    {
        if(float.IsNaN(maxDistance))
        {
            return;
        }
        
        positionVector = transform.position - originalPosition;

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
                moveVector *= -1;
                hasFlipped = !hasFlipped;
            }
        }        

        transform.Translate(moveVector);
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, OuterTarget.position);
    }
}
