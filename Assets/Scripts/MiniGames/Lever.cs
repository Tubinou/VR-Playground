using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameEvent ResetWreckBallPosition;
    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    public void ResetPosition(){
        transform.rotation = originalRotation;
        ResetWreckBallPosition.InvokeEvent();
    }
}
