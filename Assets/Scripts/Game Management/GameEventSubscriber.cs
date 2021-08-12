using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventSubscriber : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent;
    [SerializeField] UnityEvent unityEvent;

    public void onEventTrigger()
    {
        unityEvent?.Invoke();
    }

    private void OnEnable() 
    {
        gameEvent += this;
    }

    private void OnDisable() 
    {
        gameEvent -= this;
    }
}
