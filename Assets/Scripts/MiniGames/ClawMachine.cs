using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour
{
    [SerializeField] int maxHeight = 10;
    [SerializeField] int minDistance = 1;
    [SerializeField] Transform target;
    [SerializeField] SpringJoint connector;

    LineRenderer targetLine;

    void Start()
    {
        targetLine = GetComponent<LineRenderer>();
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, target.position);
    }

    void Update()
    {
        targetLine.SetPosition(0, this.transform.position);
        targetLine.SetPosition(1, target.position);
    }
}
