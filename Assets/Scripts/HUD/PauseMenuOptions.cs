using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuOptions : MonoBehaviour
{
    public void OnClickResume()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    public void OnClickExit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
