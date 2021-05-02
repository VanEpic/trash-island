using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    // get movement input support
    public float speed = 5;
    public float rotationSpeed = 360;
    public float jmpSpd = 2.0f;
    private Rigidbody rgbd;
    
    // move relative to cam yaw support
    public Camera playerCam;
    private float camYaw;
    
    // animation stuff
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inDialog) return;
        
        camYaw = playerCam.transform.rotation.eulerAngles.y;
        float camYawRad = camYaw / 180 * Mathf.PI;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3(horizontalInput * Mathf.Cos(camYawRad) + verticalInput * Mathf.Sin(camYawRad),
            0, verticalInput * Mathf.Cos(camYawRad) - horizontalInput * Mathf.Sin(camYawRad));
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }
        
        // ground checked jump
        float jumpInput = Input.GetAxis("Jump");
        bool onGround = Physics.Raycast(transform.position, Vector3.down, 0.5f);
        if (jumpInput != 0 && onGround)
        {
            rgbd.AddForce(
                new Vector3(0, jumpInput * jmpSpd,
                    0), ForceMode.Impulse);
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Animator.Play("Player-Run");
        }
        else
        {
            Animator.Play("Player-Idle");
        }
    }
    
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
