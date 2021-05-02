using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public static NPC ActiveNPC { get; }

#pragma warning disable 0649
    [SerializeField] private GameObject chatBubble;
    [SerializeField] private string yarnStartNode = "Start";
    [SerializeField] private YarnProgramVar yarnDialog;
    #pragma warning restore 0649
    
    // Start is called before the first frame update
    void Start()
    {
        chatBubble.SetActive(false);
        
    }
    void Update()
    {
        
    }
}
