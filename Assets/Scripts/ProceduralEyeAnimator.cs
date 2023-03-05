using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralEyeAnimator : MonoBehaviour
{
    // this script manages our eye plants
    [SerializeField] Transform pivot; // our eye pivot
    Vector3 originalPos, targetPos; // our original and target positions

    private void Start()
    {
        originalPos = pivot.position;
        targetPos = pivot.position;
        // start coroutine
        StartCoroutine(NewPos());
    }

    IEnumerator NewPos()
    {
        // wait a random amount of time
        yield return new WaitForSecondsRealtime(Random.Range(0.2f, 4));
        // choose a new eye positions to lerp to
        targetPos = new Vector3(originalPos.x + Random.Range(-2, 2), originalPos.y + Random.Range(-2, 2), originalPos.z + Random.Range(-2, 2));
        // restart
        StartCoroutine(NewPos());
    }


    void ProcessEye()
    {
        // look at the player
        pivot.transform.LookAt(PlayerController.instance.transform.position);
        // lerp to our targetpos
        pivot.transform.position = Vector3.Lerp(pivot.transform.position, targetPos, Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        ProcessEye();   
    }
}
