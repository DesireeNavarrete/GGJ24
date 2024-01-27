using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRigi : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Fixedupdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(rb.transform.forward * 200);
        }

    }
}
