using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public float hp;
    Rigidbody2D rb;
    float knockbackcount;
    public GameObject player;
    public float d;

    AstarPath astar;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("attack"))
        {
            knockbackcount = 0.5f;
            hp--;
           
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > d)
        {
            GetComponent<Pathfinding.AIPath>().canSearch = false;
        }
        else
        {
            GetComponent<Pathfinding.AIPath>().canSearch = true;
        }
    
        if (GetComponent<Pathfinding.AIPath>().desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(GetComponent<Pathfinding.AIPath>().desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
            if (knockbackcount <= 0)
        {
            GetComponent<Pathfinding.AIPath>().canMove = true;
        }
        else
        {
            GetComponent<Pathfinding.AIPath>().canMove = false;
         
                rb.velocity = new Vector2(-GetComponent<Pathfinding.AIPath>().velocity.x*1.5f, -GetComponent<Pathfinding.AIPath>().velocity.x);
            
            knockbackcount -= Time.deltaTime;
        }

        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
