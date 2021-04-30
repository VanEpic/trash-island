using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && Time.timeScale > 0.0f)
        {
            Time.timeScale = 0.0f;
            Instantiate(pauseMenu);
        }
        else if (Input.GetKeyDown("escape"))
        {
            Destroy(GameObject.FindWithTag("PauseMenu"));
            Time.timeScale = 1.0f;
        }
    }
}


