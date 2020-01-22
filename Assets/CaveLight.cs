using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLight : MonoBehaviour
{
    public Light dirLight;
    public Light pLight;

    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Player")
        {
             dirLight.intensity = 0;
            pLight.intensity = 30f;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player") { 
        dirLight.intensity = 1;
        pLight.intensity = 0f;
    }
    }
    

}
