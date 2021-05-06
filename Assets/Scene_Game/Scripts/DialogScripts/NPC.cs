using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : GameEventListener
{
    // public static NPC ActiveNPC { get; }

// #pragma warning disable 0649
     // [SerializeField] private GameObject chatBubble;
     // [SerializeField] private string yarnStartNode;
// #pragma warning restore 0649
    
    // Start is called before the first frame update
    void Start()
    {
        // chatBubble.SetActive(false);
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }
}
