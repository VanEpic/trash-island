using System;
using System.Collections;
using System.Collections.Generic;
using Ludiq.PeekCore;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowEquippedItem : MonoBehaviour
{
    [SerializeField] private List<Collectible> collectibles;
    [SerializeField] private List<Texture> item_textures;

    private OnPickupEvent OnPickupEvent;

    private void Start()
    {
        OnPickupEvent = new OnPickupEvent();
        OnPickupEvent.AddListener(DisplayHUD);
        gameObject.SetActive(false);
        
        // a potentially useless line, since player will never pick up same equipment twice
        //Texture texture = GetComponent<RawImage>().mainTexture;
    } 

    public void DisplayHUD(Collectible target)
    {
        gameObject.SetActive(true);
        
        for (int i = 0; i < collectibles.Count; i++)
        {
            if (target == collectibles[i])
            {
                GetComponent<RawImage>().texture = item_textures[i];
            }
        }
    }
}