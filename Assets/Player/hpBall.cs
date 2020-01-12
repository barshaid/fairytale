using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBall : MonoBehaviour
{
    public float hpAmount = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            //add hpAmount to player HP
        }
    }
}
