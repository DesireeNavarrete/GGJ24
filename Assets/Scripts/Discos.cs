using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discos : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "p1" || collision.transform.tag == "p2")
        {
            //sprint("sañldkmpakeld");
            gameObject.GetComponent<AudioSource>().Play();
            print("disco bb");
            Discosmanager.discos.Add(gameObject);
            
        }
        //print(collision.transform.name);
    }
}
