using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int move_speed = 5;

    private GameObject Camera;

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
        Animator = GetComponent<Animator>();
        
        Camera = GameObject.FindWithTag("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        hIn = Input.GetAxis("Horizontal");
        vIn = Input.GetAxis("Vertical");

        // control for camera-to-player yaw
        xMove = hIn * Time.deltaTime;
        zMove = vIn * Time.deltaTime;
        // TODO switch movement direction to be relative to camera rotation
        float cam_rotY_rads = Camera.transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        Vector3 new_pos = transform.position;
        new_pos.x += xMove * move_speed * Mathf.Sin(cam_rotY_rads) + zMove * move_speed * Mathf.Sin(cam_rotY_rads);
        new_pos.z += zMove * move_speed * Mathf.Cos(cam_rotY_rads) + xMove * move_speed * Mathf.Cos(cam_rotY_rads);
        transform.Translate(xMove * move_speed, 0, zMove * move_speed);
        //transform.position = new_pos;
        
        // switch player rotation to match movement direction
        transform.Rotate(0, Mathf.Lerp(0, 360*xMove, 0.3f), 0);


        if (hIn != 0 || vIn != 0)
        {
            Animator.Play("Player-Run");
        }
        else
        {
            Animator.Play("Player-Idle");
        }
    }
}
