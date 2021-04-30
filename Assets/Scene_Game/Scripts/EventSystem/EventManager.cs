using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    private static List<UnityAction<Collectible>> pickupListeners = new List<UnityAction<Collectible>>();
    private static List<Collectible> pickupInvokers = new List<Collectible>();

    #endregion

    public static void AddOnPickupEventListener(UnityAction<Collectible> listener)
    {
        pickupListeners.Add(listener);
        foreach (var invoker in pickupInvokers)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddOnPickupEventInvoker(Collectible invoker)
    {
        pickupInvokers.Add(invoker);
        foreach (var listener in pickupListeners)
        {
            invoker.AddListener(listener);
        }
    }

    
}
