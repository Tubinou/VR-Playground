using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] GameEvent DoorOpened;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.CompareTag("Catalyst"))
        {
            DoorOpened?.InvokeEvent();
        }
    }
}
