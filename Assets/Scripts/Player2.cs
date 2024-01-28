using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    public float rotationSpeed;
    public float moveHorizontal;
    public float speed, speeddecrease, maxspeed;
    public float plusspeed = 2;
    public int gear;
    public bool clutch = false;
    public bool clutchable = false;
    public int[] maxspeedarray;
    public Rigidbody[] rigis;
    public GameObject[] comebacks;

    // Animator

    public bool jump, moving;
    public Animator myAnim;

    void Start()
    {
        rigis = GetComponentsInChildren<Rigidbody>(true);
        suelo = false;
        foreach (Rigidbody r in rigis)
        {
            r.isKinematic = true;

        }
        myAnim.enabled = true;
        rotationSpeed = 10;
        comebacks = GameObject.FindGameObjectsWithTag("comeback");
    }

    GameObject respawn_closer;
    Vector3 closer_real,closer;
    public void which_closer()
    {
        Vector3 closer = new Vector3(100000f, 100000f, 100000f);
        foreach (GameObject cb in comebacks)
        {
            Vector3 distance = gameObject.transform.position - cb.transform.position;
            if (distance.magnitude < closer.magnitude)
            {
                closer = distance;
                respawn_closer = cb;

            }
        }
        print(respawn_closer);
        print(closer);
        closer_real = closer;

    }
    IEnumerator jumping()
    {
        myAnim.SetBool("jump", true);
        yield return new WaitForSeconds(2f);
        myAnim.SetBool("jump", false);
    }
    RaycastHit hit;
    public bool suelo;
    Vector3 movement;
    private void Update()
    {




        //Raycast

        if (suelo == false)
        {
            if (Physics.Raycast(gameObject.transform.position, Vector3.down * 50, out hit, 10f))
            {
                if (hit.collider.tag == "suelo")
                {
                    foreach (Rigidbody r in rigis)
                    {
                        r.isKinematic = false;
                    }
                    myAnim.enabled = false;
                    suelo = true;
                    StartCoroutine("destroy_instantiate");
                    print(hit.collider.name + "suelo");
                }
                else
                    suelo = false;
                print(hit.collider.name + "else");


            }

        }



        //if (suelo == false)
        //{
        //    print("sdfsdf");
        //    foreach (Rigidbody r in rigis)
        //    {
        //        r.isKinematic = false;
        //        gameObject.SetActive(false);
        //        StartCoroutine("destroy_instantiate");




        //    }
        //}

        //Animator


        if (Input.GetButtonDown("Space"))
        {
            StartCoroutine("jumping");
        }

        if (speed >= 0.1f)
        {
            myAnim.SetBool("moving", true);
        }
        else
        {
            myAnim.SetBool("moving", false);
        }



        //----------------------

        moveHorizontal = Input.GetAxis("P1");

        movement = new Vector3(0, moveHorizontal * 15, 0);
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

        //print(clutch);
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
                //print("subir marcha");
                gear_change();
            }

            if (Input.GetButtonDown("L1"))//subir marcha
            {
                //print("bajar marcha");
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

    public GameObject spawn;
    public GameObject prefabPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "obstaculo")
        {

            foreach (Rigidbody r in rigis)
            {
                print("brrrrrrrrrrrr");
                r.isKinematic = false;
            }
            myAnim.enabled = false;
            StartCoroutine("destroy_instantiate");
        }

    }
    IEnumerator destroy_instantiate()
    {
        if (suelo)
        {
            which_closer();
            //print(closer_real);
            print("fuera");
            yield return new WaitForSeconds(3f);
            Instantiate(prefabPlayer, respawn_closer.transform.position, spawn.transform.rotation);
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }
        else
        {

            //print(closer_real);
            print("dentro");
            yield return new WaitForSeconds(3f);
            Instantiate(prefabPlayer, spawn.transform.position, spawn.transform.rotation);
            yield return new WaitForSeconds(.3f);
            Destroy(gameObject);
        }



    }
}
