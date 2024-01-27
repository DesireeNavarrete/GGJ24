using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    public float moveHorizontal;
    public float rotationSpeed;
    void Start()
    {

    }

    

    private void Update()
    {

        moveHorizontal = Input.GetAxis("P2");

        Vector3 movement = new Vector3(0, moveHorizontal*15, 0);
        transform.Rotate(movement * rotationSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime);
    }

}
