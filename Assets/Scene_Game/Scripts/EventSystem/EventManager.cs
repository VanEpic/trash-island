using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields

    private static List<UnityAction<CollectibleTrigger>> pickupListeners = new List<UnityAction<CollectibleTrigger>>();
    private static List<CollectibleTrigger> pickupInvokers = new List<CollectibleTrigger>();

    #endregion

    public static void AddOnPickupEventListener(UnityAction<CollectibleTrigger> listener)
    {
        pickupListeners.Add(listener);
        foreach (var invoker in pickupInvokers)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddOnPickupEventInvoker(CollectibleTrigger invoker)
    {
        pickupInvokers.Add(invoker);
        foreach (var listener in pickupListeners)
        {
            invoker.AddListener(listener);
        }
    }

    
}
