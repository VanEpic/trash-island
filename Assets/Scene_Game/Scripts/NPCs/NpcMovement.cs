using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NpcMovement : MonoBehaviour
{
    [YarnCommand("jumpNPC")]
    public void JumpNpc()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(
            new Vector3(0,  3f, 0), ForceMode.Impulse);
    }
}
