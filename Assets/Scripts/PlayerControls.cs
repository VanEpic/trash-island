using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private int move_speed = 5;
    
    // need camera to compute proper on-screen player movement
    private Camera portable_cam;
    private float cam_yaw;
    
    // get movement input support
    private float hIn;
    private float vIn;
    private float xMove;
    private float zMove;
    
    // animation stuff
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        portable_cam = GetComponentInChildren<Camera>();
        cam_yaw = portable_cam.transform.rotation.eulerAngles.y;

        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hIn = Input.GetAxis("Horizontal");
        vIn = Input.GetAxis("Vertical");
        
        // control for camera-to-player yaw
        xMove = hIn * Time.deltaTime - vIn * Time.deltaTime * cam_yaw / 360;
        zMove = vIn * Time.deltaTime + hIn * Time.deltaTime * cam_yaw / 360;
        transform.Translate(xMove * move_speed, 0, zMove * move_speed);
        
        // switch player rotation to match movement direction
        Vector3 new_rotation = new Vector3(0,360*xMove, 0);
        //transform.Rotate(new_rotation);
        //transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new_rotation, 0.5f);
        transform.Rotate(0, Mathf.Lerp(0, new_rotation.y, 0.3f), 0);
        
        if (xMove != 0 || zMove != 0)
        {
            Animator.Play("Player-Run");
        }
        else
        {
            Animator.Play("Player-Idle");
        }
    }
}
