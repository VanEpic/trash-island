using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    
    
    public void Raise()
    {
        // listeners = listeners.Where(x => listeners.FindAll(x).Count == 1).ToList();
        // Clean();
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    private void Clean()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            if (listeners[i] == null) listeners.Remove(listeners[i]);
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        // listeners.Clear();
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
