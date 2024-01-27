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
    public int gear;
    public bool clutch = false;
    public bool clutchable = false;
    public int[] maxspeedarray;

    void Start()
    {

    }
    private void Update()
    {

        moveHorizontal = Input.GetAxis("P1");

        Vector3 movement = new Vector3(0, moveHorizontal * 15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);
       
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
        print(clutch);
        if (Input.GetAxis("L2") != 0)
        {
            clutch = true;
        }
        else
        {
            clutch = false;
        }
        if (clutch == true)
        {
            gear_change();
        }
        print(gear);
        print(clutchable);
        print(clutch);
    }

    void gear_change()
    {
        if (gear > 4)
        {
            gear = 4;
        }
        if (gear < 0)
        {
            gear = 0;
        }
        if (canChange())
        {
            gear += 1;
        }
       
    }

    bool canChange()
    {
        if (gear == 1)
        {
            maxspeed = maxspeedarray[1];
            if (speed > maxspeed - 2f & speed <= maxspeed)
            {
                return clutchable = true;
            }
            else
            {
                return clutchable = false;
            }
        }
        if (gear == 2)
        {
            maxspeed = maxspeedarray[2];
            if (speed > maxspeed - 2f & speed <= maxspeed)
            {
                return clutchable = true;
            }
            else
            {
                return clutchable = false;
            }
        }
        if (gear == 3)
        {
            maxspeed = maxspeedarray[3];
            if (speed > maxspeed - 2f & speed <= maxspeed)
            {
                return clutchable = true;
            }
            else
            {
                return clutchable = false;
            }
        }
        if (gear == 4)
        {
            maxspeed = maxspeedarray[4];
            if (speed > maxspeed - 2f & speed <= maxspeed)
            {
                return clutchable = true;
            }
            else
            {
                return clutchable = false;
            }
        }
        else
        {
            return clutchable = false;
        }
    }
}
