using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity = 100f;

    public Transform target;

    float xRotation = 0f;

    public Vector3 offset;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, mouseX, 0f);
        target.Rotate(Vector3.up * mouseX);

        transform.position = target.position + offset;

    }

}
    