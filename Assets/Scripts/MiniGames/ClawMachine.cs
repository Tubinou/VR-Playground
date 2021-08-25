using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Rigidbody connectedBody;
    [SerializeField] Transform movementLever;

    LineRenderer targetLine;
    public bool isMovingHorizontally = true;
    Vector3 originalPosition;
    Quaternion originalRotation;

    public void toggleHorizontalMovement()
    {
        isMovingHorizontally = !isMovingHorizontally;
    }

    public void ResetWreckBallPosition(){
        connectedBody.velocity = Vector3.zero;
    }

    void Start()
    {
        targetLine = GetComponent<LineRenderer>();
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, target.position);

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, target.position);

        if(isMovingHorizontally && movementLever.rotation.x != 0)
        {
            transform.Translate(new Vector3(0f, 0f, -movementLever.rotation.x));
        }

        if(isMovingHorizontally && movementLever.rotation.z != 0 )
        {
            transform.Translate(new Vector3(movementLever.rotation.z, 0f, 0f));
        }
    }
}
