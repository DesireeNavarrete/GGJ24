using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estopacollider : MonoBehaviour
{
    public float timer, minus;
    public bool completed = false;

    public GameObject bobesponja;

    public GameObject p1;

    private void Start()
    {
        timer = 1.5f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (p1 || other.transform.tag == "p2" && completed == false)
        {
            timer -= minus * Time.deltaTime;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 1.5f;
    }

    private void Update()
    {
        if (timer <= 0)
        {
            completed = true;
        }

        if (completed)
        {
            bobesponja.GetComponent<Animator>().SetBool("bob", true);
            
        }
    }
}
