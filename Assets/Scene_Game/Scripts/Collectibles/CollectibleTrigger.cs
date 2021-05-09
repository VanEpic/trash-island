using System;
using System.Collections;
using System.Collections.Generic;
using Scene_Game.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CollectibleTrigger : MonoBehaviour
{
    private OnPickupEvent onPickupEvent;
    
#pragma warning disable 0649
    [FormerlySerializedAs("PlayerNearCollectibleEvent")] 
    [SerializeField] private GameEvent playerNearCollectibleEvent;
    // [SerializeField] private GameEvent playerLeftEvent;
#pragma warning restore 0649

    private void OnEnable()
    {
        onPickupEvent = new OnPickupEvent();
        EventManager.AddOnPickupEventInvoker(this);
    }

    public void AddListener(UnityAction<CollectibleTrigger> listener)
    {
        onPickupEvent.AddListener(listener);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            playerNearCollectibleEvent.Raise();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && Input.GetKey("e"))
        {
            onPickupEvent?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            playerNearCollectibleEvent.Raise();
        }
    }
}
