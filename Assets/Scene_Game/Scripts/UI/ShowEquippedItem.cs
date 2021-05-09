using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowEquippedItem : MonoBehaviour
{
    public List<CollectibleTrigger> collectibles;
    public List<Texture> item_textures;

    private void Start()
    {
        EventManager.AddOnPickupEventListener(DisplayHUD);
    } 

    public void DisplayHUD(CollectibleTrigger target)
    {
        gameObject.SetActive(true);

        // tell UI to change sprite
        for (int i = 0; i < collectibles.Count; i++)
        {
            if (target == collectibles[i])
            {
                GetComponent<RawImage>().texture = item_textures[i];
            }
        }
    }
}
