using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "sprite")
        {
            if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
            {

                col.GetComponentInParent<combat>().hp++;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(1, 0.237f, 0, 1)).ToString())
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
            else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0, 0.585f, 0)).ToString())
            {
                col.GetComponentInParent<combat>().wind++;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0.1415094f, 0.1415094f, 0.1415094f)).ToString())
            {
                col.GetComponentInParent<combat>().hp -= 3;
            }else if (gameObject.CompareTag("crystal"))
            {

            }

            Destroy(transform.parent.gameObject);

        }
    }
    private void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0.1415094f, 0.1415094f, 0.1415094f)).ToString())
        {
            transform.localScale /= 2;
            destroy();

        }
    }
    void Update()
    {
        Vector3 curr = transform.localPosition;
        if (gameObject.GetComponent<SpriteRenderer>().color.ToString() == (new Color(0.1415094f, 0.1415094f, 0.1415094f)).ToString())
        {
            curr = Vector3.up * Mathf.Cos(Time.time * 6);

        }
        else
        {
            curr = Vector3.up * Mathf.Cos(Time.time);
        }
        transform.localPosition = curr;


    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(transform.parent.gameObject);
        
        
    }
}
