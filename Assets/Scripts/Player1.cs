using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public float rotationSpeed;
    public float moveHorizontal;
    public float speed, speeddecrease, maxspeed, speedP;
    public float plusspeed = 2;
    public int gear;
    public bool clutch = false;
    public bool clutchable = false;
    public int[] maxspeedarray;
    public Rigidbody rb;
    public Rigidbody[] rigis;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rigis = FindObjectsOfType<Rigidbody>();

    }

    private void Update()
    {
        moveHorizontal = Input.GetAxis("P1");

        Vector3 movement = new Vector3(0, moveHorizontal * 15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("reee"))//correr
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
        if (Input.GetAxis("L2") != 0)//embrague
        {
            clutch = true;
        }
        else
        {
            clutch = false;
        }
        //if (clutch == true)
        //{
        //    gear_change();
        //}
        //print(gear);
        //print(clutchable);
        //print(clutch);


        if (clutch)
        {
            if (Input.GetButtonDown("R1"))//subir marcha
            {
                print("subir marcha");
                gear_change();
            }

            if (Input.GetButtonDown("L1"))//subir marcha
            {
                print("bajar marcha");
            }
        }
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
        if (CanChange())
        {
            gear += 1;
        }

    }

    bool CanChange()//marchas
    {
        switch (gear)
        {
            case 1:
                Debug.Log("gear 1");
                //maxspeed = maxspeedarray[1];
                if (speed > maxspeed - 2f)
                {
                    return clutchable = true;
                }
                else
                {
                    return clutchable = false;
                }

            //case 2:

            //    maxspeed = maxspeedarray[2];
            //    if (speed > maxspeed - 2f && speed <= maxspeed)
            //    {
            //        return clutchable = true;
            //    }
            //    else
            //    {
            //        return clutchable = false;
            //    }

            //case 3:

            //    maxspeed = maxspeedarray[3];
            //    if (speed > maxspeed - 2f && speed <= maxspeed)
            //    {
            //        return clutchable = true;
            //    }
            //    else
            //    {
            //        return clutchable = false;
            //    }

            //case 4:

            //    maxspeed = maxspeedarray[4];
            //    if (speed > maxspeed - 2f && speed <= maxspeed)
            //    {
            //        return clutchable = true;
            //    }
            //    else
            //    {
            //        return clutchable = false;
            //    }

            default:
                return clutchable = false;
                break;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "obstaculo")
        {
            foreach(Rigidbody r in rigis)
            {
                r.isKinematic = false;
            }
        }
        {

        }
    }
}
