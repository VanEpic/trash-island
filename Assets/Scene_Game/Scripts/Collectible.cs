using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public OnPickupEvent OnPickupEvent;

    private void OnEnable()
    {
        OnPickupEvent = new OnPickupEvent();
        EventManager.AddOnPickupEventInvoker(this);
    }

    public void AddListener(UnityAction<Collectible> listener)
    {
        OnPickupEvent.AddListener(listener);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            OnPickupEvent?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
