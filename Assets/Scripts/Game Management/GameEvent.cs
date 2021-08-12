using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event", order = 2)]
public class GameEvent : ScriptableObject
{
    public List<GameEventSubscriber> subscribers = new List<GameEventSubscriber>();

    public void InvokeEvent()
    {
        for(int index = 0; index < subscribers.Count; index++)
        {
            subscribers[index].onEventTrigger();
        }
    }

    public static GameEvent operator+(GameEvent gameEvent, GameEventSubscriber subscriber)
    {
        gameEvent.subscribers.Add(subscriber);
        return gameEvent;
    }

    public static GameEvent operator-(GameEvent gameEvent, GameEventSubscriber subscriber)
    {
        gameEvent.subscribers.Remove(subscriber);
        return gameEvent;
    }
}
