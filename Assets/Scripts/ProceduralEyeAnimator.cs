using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralEyeAnimator : MonoBehaviour
{
    // this script manages our eye plants
    [SerializeField] Transform pivot; // our eye pivot

    void ProcessEye()
    {
        // look at the player
        pivot.transform.LookAt(PlayerController.instance.transform.position);
    }

    private void FixedUpdate()
    {
        ProcessEye();   
    }
}
