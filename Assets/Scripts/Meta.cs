using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "p1")
        {
            SceneManager.LoadScene("P1");
        }


        if (collision.transform.tag == "p2")
        {
            SceneManager.LoadScene("P2");

        }

        //print(collision.transform.name);
    }
}
