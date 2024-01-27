using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public float rotationSpeed;
    public float moveHorizontal;
    void Start()
    {

    }

    


    private void Update()
    {

        moveHorizontal = Input.GetAxis("P1");

        Vector3 movement = new Vector3(0, moveHorizontal*15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime);
    }

}
