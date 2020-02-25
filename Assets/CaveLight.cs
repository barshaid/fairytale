using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
     Light dirLight;


    private void Start()
    {
        dirLight = FindObjectsOfType<Light>()[1];
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponentInChildren<Light>().intensity = 10f;
            dirLight.intensity = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponentInChildren<Light>().intensity = 10f;
            dirLight.intensity = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            col.gameObject.GetComponentInChildren<Light>().intensity = 0;
            dirLight.intensity = 1;
    }
    }
    

}
