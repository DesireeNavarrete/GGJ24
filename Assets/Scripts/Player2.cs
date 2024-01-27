using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

public class Player2 : MonoBehaviour
{
    public float moveHorizontal;
    public float rotationSpeed;
    public float speed, speeddecrease, maxspeed;
    public float plusspeed = 2;

    void Start()
    {

    }

    private void Update()
    {

        moveHorizontal = Input.GetAxis("P2");

        Vector3 movement = new Vector3(0, moveHorizontal*15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);

        print(Input.GetButtonDown("c1rrr"));
        if (Input.GetButtonDown("c1rrr"))
        {
            speed += plusspeed;
        }
        speed -= speeddecrease;
        if (speed < 0)
        {
            speed = 0;
        }
        if (speed > maxspeed)
        {
            speed = maxspeed;

        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
