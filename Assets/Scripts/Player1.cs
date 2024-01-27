using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public float rotationSpeed;
    public float moveHorizontal;
    public float speed, speeddecrease, maxspeed;
    public float plusspeed = 2;

    void Start()
    {

    }
    private void Update()
    {

        moveHorizontal = Input.GetAxis("P1");

        Vector3 movement = new Vector3(0, moveHorizontal * 15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);

        print(Input.GetButtonDown("reee"));
        if (Input.GetButtonDown("reee"))
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
