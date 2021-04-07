using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
    
}
