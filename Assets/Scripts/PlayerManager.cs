using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject spawnP1, spawnP2;
    public GameObject p1, p2;
    void Start()
    {
        Instantiate(p1, spawnP1.transform.position, Quaternion.identity);
        Instantiate(p2, spawnP2.transform.position, Quaternion.identity);

    }

    void Update()
    {
        
    }
}
