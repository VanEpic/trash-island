using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CursorControls : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Cursor.lockState != CursorLockMode.Locked && Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
