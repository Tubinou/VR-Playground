using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    [SerializeField] Text textField;

    int triggerButton = 0;
    int grabButton = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerPressed()
    {
        triggerButton += 1;
        textField.text = $"Triggered {triggerButton}, Grabbed {grabButton}";        
    }

    public void GrabPressed()
    {
        grabButton += 1;
        textField.text = $"Triggered {triggerButton}, Grabbed {grabButton}";
    }

    public void OnHover()
    {
        textField.text = $"Hovering...";
    }
}
