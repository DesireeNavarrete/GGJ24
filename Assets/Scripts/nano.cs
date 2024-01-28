using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nano : MonoBehaviour
{
    public GameObject nanoAnim;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "p1" || other.transform.tag == "p2")
        {
            print("sañldkmpakeld");
            nanoAnim.GetComponent<Animator>().SetBool("nano", true);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nanoAnim.GetComponent<Animator>().SetBool("nano", false);

    }
}
