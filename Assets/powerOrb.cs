using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "sprite")
        {
            if (gameObject.GetComponent<SpriteRenderer>().color == Color.white) {

                col.GetComponentInParent<combat>().hp++;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(1, 0.237f, 0,1)).ToString())
            {
                col.GetComponentInParent<combat>().fire++;
            }
        else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0, 1, 1)).ToString())
            {
                col.GetComponentInParent<combat>().ice++;
    }
    else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0, 0.585f, 0)).ToString())
    {
        col.GetComponentInParent<combat>().wind++;
    }
            
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
