using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollos : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "p1" || collision.transform.tag == "p2")
        {
            print("sañldkmpakeld");
            gameObject.GetComponent<AudioSource>().Play();
        }

        //print(collision.transform.name);
    }
}
