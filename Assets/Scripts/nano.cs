using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nano : MonoBehaviour
{
    public GameObject nanoAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "p1" || other.transform.tag == "p2")
        {
            gameObject.GetComponent<AudioSource>().Play();
            nanoAnim.GetComponent<Animator>().SetBool("nano", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //nanoAnim.GetComponent<Animator>().SetBool("nano", false);

    }
}
