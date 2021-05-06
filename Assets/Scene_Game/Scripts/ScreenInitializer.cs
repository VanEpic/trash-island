using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// set player cam projection texture to size of main camera based on screen ratio
/// </summary>
public class ScreenInitializer : MonoBehaviour
{
    [FormerlySerializedAs("screen")] 
    public GameObject billboard;
    
    // Start is called before the first frame update
    void Awake()
    {
        float screenRatio = Screen.width / (float)Screen.height;
        float mainCamOrthoSize = GetComponent<Camera>().orthographicSize;
        Vector3 screenScale = new Vector3(mainCamOrthoSize * 2 * screenRatio, mainCamOrthoSize * 2, 1);
        
        billboard.transform.localScale = screenScale;

        Vector3 screenCurPos = billboard.transform.position;
        billboard.transform.position = new Vector3(GetComponent<Camera>().transform.position.x, screenCurPos.y, screenCurPos.z);
        
    }
}
