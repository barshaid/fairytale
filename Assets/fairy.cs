using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairy : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= (Random.Range(5.0f, 15.0f) / 10.0f);
    }

}
