using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector3 movement;
    public float speed;
    Vector2 moveValue;
    Rigidbody rigi;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector3(moveValue.x, rigi.velocity.y, moveValue.y);
        rigi.velocity = movement;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //We calculate the movement of the player
        if (movement != Vector3.zero)
        {

            Quaternion rot = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));//We look forward the direction we are walking to.
            rot = rot.normalized;//We normalize the rotation.
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 6 * Time.deltaTime);//We interpolate the rotation.

        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
    }

}
