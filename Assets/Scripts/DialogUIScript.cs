using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUIScript : MonoBehaviour
{
    private bool inDialog;
    
    public void OnDialogEnd()
    {
        inDialog = false;
    }
    
    /// <summary>
    /// Interact with NPC for dialogue
    /// </summary>
    void Interact()
    {
        inDialog = Input.GetButtonDown("E");
    }
}
