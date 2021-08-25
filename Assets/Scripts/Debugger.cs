using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    [SerializeField] Text textField;

    int triggerButton = 0;
    int grabButton = 0;

    public static string debugText;

    void Update()
    {
        if(debugText != string.Empty){
            textField.text = $"Debug text {debugText}";
        }
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
