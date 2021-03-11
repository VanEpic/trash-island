using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public event Action<Collectible> OnPickup;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            OnPickup?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
