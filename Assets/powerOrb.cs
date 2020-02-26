using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<combat>().hp++;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector3 curr = transform.localPosition;


            curr = Vector3.up * Mathf.Cos(Time.time);
        transform.localPosition = curr;
    }
}
