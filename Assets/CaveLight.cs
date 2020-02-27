using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
    
    public Light dirLight;
    Light pLight;


    private void Start()
    {
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
        pLight= GameObject.Find("Player").GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dirLight.intensity = 0;
            pLight.intensity = 10f;

        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dirLight.intensity = 0;
            pLight.intensity = 10f;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            pLight.intensity = 0;
            dirLight.intensity = 1;
    }
    }
    

}
