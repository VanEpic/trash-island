using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] _equipables;

    //[SerializeField] private UnityEvent<Collectible> OnPickupEvent;
    private OnPickupEvent OnPickupEvent;

    private List<Collectible> _collectiblesRemaining;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        OnPickupEvent = new OnPickupEvent();
        
        _collectiblesRemaining = new List<Collectible>(_equipables);

        foreach (var collectible in _collectiblesRemaining)
        {
            collectible.OnPickup += HandlePickup;
        }
    }

    void HandlePickup(Collectible collectible)
    {
        _collectiblesRemaining.Remove(collectible);
        OnPickupEvent.Invoke(collectible);
    }
}
