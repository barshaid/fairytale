using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
    public Light dirLight;
    public Light pLight;
    private void OnTriggerEnter(Collider other)
    {
        dirLight.intensity = 0;
        pLight.intensity = 50f;
    }

    
}
