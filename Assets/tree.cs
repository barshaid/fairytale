using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public LayerMask groundLayer;

   
    void Start()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y - 3.5f);
        Vector2 direction = Vector2.down;
        Vector3 curr = transform.localPosition;
        float distance = 3f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            
            if (hit.collider.name.Substring(0, 1) == "g" || hit.collider.name.Substring(0, 1) == "h")
            {
                curr.y += 4.8f;
                
                transform.localPosition = curr;
            }
            else if (hit.collider.name.Substring(0, 1) == "l")
            {
                curr.y += 0.8f  ;
                transform.localPosition = curr;
            }
            else if (hit.collider.name.Substring(0, 1) == "m")
            {
                curr.y += 2.8f;
                transform.localPosition = curr;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 4.3f), Vector2.down, Color.red);
    }
}
