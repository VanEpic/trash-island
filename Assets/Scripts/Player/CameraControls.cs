using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    /*private float sensitivity = 3.0f;
    private float mouse_horizontal;
    private float mouse_vertical;
    
    // keep camera at same distance from player support
    private float max_dist;
    private Transform player_transform;
    private Vector3 player_position;
    private Vector3 new_pos;

    // Start is called before the first frame update
    void OnEnable()
    {
        player_transform = GameObject.FindWithTag("Player").transform;
        max_dist = Vector3.Distance(transform.position, player_transform.position);
        if (max_dist > 9) 
            max_dist = 9;

        Cursor.lockState = CursorLockMode.Locked;
    }*/

    // Update is called once per frame
    void Update()
    {
        /*
        player_position = player_transform.position;

        mouse_horizontal = Input.GetAxis("Mouse X");
        mouse_vertical = Input.GetAxis("Mouse Y");

        // load new position based on input
        new_pos = transform.position;
        new_pos.x -= Time.deltaTime * sensitivity * mouse_horizontal * Mathf.Cos(
            transform.rotation.eulerAngles.y / 180 * Mathf.PI);
        new_pos.y -= Time.deltaTime * sensitivity * mouse_vertical * Mathf.Cos(transform.rotation.eulerAngles.x / 180 * Mathf.PI);
        new_pos.z += Time.deltaTime * sensitivity * mouse_horizontal * Mathf.Sin(
        transform.rotation.eulerAngles.y / 180 * Mathf.PI) - Time.deltaTime * sensitivity * mouse_vertical * Mathf.Sin(transform.rotation.eulerAngles.x / 180 * Mathf.PI);;

        // check new position and adjust to stay inside sphere with r = max_dist
        float distance = Vector3.Distance(new_pos, player_position);
        if (distance > max_dist + 1)
        {
            new_pos =  Vector3.Lerp(new_pos, Vector3.MoveTowards(new_pos,
                player_position, Time.deltaTime * distance), 0.5f);
        }
        else if (distance < max_dist - 1)
        {
            new_pos = Vector3.Lerp(new_pos, Vector3.MoveTowards(new_pos,
                new_pos - player_position, Time.deltaTime * distance), 0.5f);
        }
        
        transform.position = new_pos;
        
        // constantly rotate towards player
        var targetDirection = player_position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
*/
        if (Input.GetKey("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
