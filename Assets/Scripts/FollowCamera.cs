using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;//target
    public float smooth;
    public Vector3 offset;


    void LateUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smooth);
        transform.position = smoothedPos;
    }
}
