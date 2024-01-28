using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manejador_de_escenas : MonoBehaviour
{

    public GameObject panel_controles;

    // Start is called before the first frame update
    void Start()
    {
        panel_controles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Puta()
    {
        SceneManager.LoadSceneAsync("SampleScene 1");
    }

    public void VerControles()
    {
        panel_controles.SetActive(true);
    }

    public void VolverMenu ()
    {
        panel_controles.SetActive(false);
    }
}
