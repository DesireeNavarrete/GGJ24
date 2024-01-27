using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{
    public GameObject player;//target
    public Vector3 player_trans;
    public Vector3 player_back;

    // the target to follow
    public Transform followTarget;
    // local offset to e.g. place the camera behind the target object etc
    public Vector3 positionOffset;
    // how smooth the camera position is updated, smaller value -> slower
    public float interpolation = 5f;


    void getback()
    {
        
        //player_back = player.position.z - 100f;
        //player_trans = transform.TransformPoint(0f, 0f, player_back);
    }
    

    public void Update()
    {
        // target position taking the targets rotation and the offset into account
        var targetPosition = followTarget.position + followTarget.forward * positionOffset.z + followTarget.right * positionOffset.x + followTarget.up * positionOffset.y;

        // move smooth towards this target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolation * Time.deltaTime);

        // rotate to look at the target without rotating in Z
        transform.LookAt(followTarget);
    }

    

   
}
