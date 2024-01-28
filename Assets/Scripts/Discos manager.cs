using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discosmanager : MonoBehaviour
{
    public static List<GameObject> discos = new List<GameObject>();

    private void Update()
    {
        print(discos.Count);
        if (discos.Count >= 2)
        {
            discos[0].GetComponent<AudioSource>().Stop();
            discos.Clear();
        }
    }

}
